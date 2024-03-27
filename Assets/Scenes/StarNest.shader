Shader "FX/StarNest" {
	Properties {
		_MainTex ("Texture Sampler (UV Only)", 2D) = "grey" {}
		
		
		// Приближение фона.
		_Zoom ("Zoom", Float) = 800
		
		_Color ("Main Color", Color) = (1,1,1,1)	
		
		[Toggle(CLAMPOUT)] _CLAMPOUT("Clamp Output with Main Color", Float) = 0
		
		//Прокручивается в этом направлении с течением времени. Установите «w» на ноль, чтобы остановить прокрутку.
		_Scroll ("Scrolling direction (x,y,z) * w * time", Vector) = (3, 1, .6, .01)
		
		//Положение центра в пространстве и времени.
		_Center ("Center Position (x, y, z, time)", Vector) = (1, .3, .5, 0)
		
		//Углы поворота.
		_Rotation ("Rotation (x,y,z)*w angles", Vector) = (35, 25, 75, .1)
		
		//Итерации внутреннего цикла.
		//Чем выше значение, тем более удаленные объекты визуализируются.
		_Iterations ("Iterations", Range(1, 30)) = 17
		
		//Этапы объемного рендеринга. Каждый «шаг» визуализирует больше объектов на всех расстояниях.
		//Это приводит к более высокому снижению производительности, чем итерации.
		_Volsteps ("Volumetric Steps", Range(1,40)) = 20
		
		//Магическое число. Оптимальные значения составляют около 400-600.
		_Formuparam ("Formuparam", Float) = 530
		
		//Насколько дальше идет каждый шаг объема
		_StepSize ("Step Size", Float) = 130
		
		//Скорость повторения фрактала
		//Маленькие числа заняты и дают много повторений
		//Высокие числа очень редки
		_Tile ("Tile", Float) = 700
		
		//Шкала яркости.
		_Brightness ("Brightness", Float) = 2
		//Обилие Темной материи (вдалеке).
		//Видимо с Volsteps >= 8 (на 7 его тяжело увидеть)
		_Darkmatter ("Dark Matter", Float) = 25
		//Яркость удаленных объектов (или тусклость) - удаленные объекты
		_Distfading ("Distance Fading", Float) = 68
		//Насыщенность цвета
		_Saturation ("Saturation", Float) = 85
		
	}

	SubShader {
		Tags { "Queue"="Geometry" "RenderType"="Opaque" }
		Cull Off
		
		
		CGPROGRAM
		
		
		#pragma surface surf Lambert
		#pragma multi_compile __ CLAMPOUT
		#include "UnityCG.cginc"
		
		fixed4 _Color;
		
		int _Volsteps;
		int _Iterations;
		sampler2D _MainTex;
		
		float4 _Scroll;
		float4 _Center;
		float _CamScroll;
		float4 _Rotation;
		
		float _Formuparam;
		float _StepSize;
		
		float _Zoom;
		
		float _Tile;
		
		float _Brightness;
		float _Darkmatter;
		float _Distfading;
		float _Saturation;
		
		struct Input {
			float2 uv_MainTex;
		};
		
		
		
		void surf (Input IN, inout SurfaceOutput o) {
			half3 col = half3(0, 0, 0);
			float zoom = _Zoom / 1000;
			float2 uv = IN.uv_MainTex;
			uv -= .5;
			
			half3 dir = float3(uv * zoom, 1);
			
			float time = _Center.w + _Time.x;
			
			//Немасштабируемые параметры (исходные параметры для них обычно находятся в диапазоне 0...1)
			// Их масштабирование значительно упрощает точную настройку шейдера в инспекторе.
			float brightness = _Brightness / 1000;
			float stepSize = _StepSize / 1000;
			float3 tile = abs(float3(_Tile, _Tile, _Tile)) / 1000;
			float formparam = _Formuparam / 1000;
			
			float darkmatter = _Darkmatter / 100;
			float distFade = _Distfading / 100;
			
			float3 from = _Center.xyz;
			
			//прокручиваем во времени
			from += _Scroll.xyz * _Scroll.w * time;
			//прокрутка от позиции камеры
			
			
			
			//Применяем вращение, если оно включено
			float3 rot = _Rotation.xyz * _Rotation.w;
			if (length(rot) > 0) {
				float2x2 rx = float2x2(cos(rot.x), sin(rot.x), -sin(rot.x), cos(rot.x));
				float2x2 ry = float2x2(cos(rot.y), sin(rot.y), -sin(rot.y), cos(rot.y));
				float2x2 rz = float2x2(cos(rot.z), sin(rot.z), -sin(rot.z), cos(rot.z));
				
				dir.xy = mul(rz, dir.xy);
				dir.xz = mul(ry, dir.xz);
				dir.yz = mul(rx, dir.yz);
				from.xy = mul(rz, from.xy);
				from.xz = mul(ry, from.xz);
				from.yz = mul(rx, from.yz);
			}
			
			

			//объемный рендеринг
			float s = 0.1, fade = 1.0;
			float3 v = float3(0, 0, 0);
			for (int r = 0; r < _Volsteps; r++) {
				float3 p = abs(from + s * dir * .5);
				
				p = abs(float3(tile - fmod(p, tile*2)));
				float pa,a = pa = 0.;
				for (int i = 0; i < _Iterations; i++) {
					p = abs(p) / dot(p, p) - formparam;
					a += abs(length(p) - pa);
					pa = length(p);
				}
				//Темная материя
				float dm = max(0., darkmatter - a * a * .001);
				if (r > 6) { fade *= 1. - dm; } // Рендеринг далекой темной материи
				a *= a * a; //добовляем контраст
				
				v += fade;
				
				// раскраска в зависимости от расстояния
				v += float3(s, s*s, s*s*s*s) * a * brightness * fade;
				
				// замирание на расстоянии
				fade *= distFade;
				s += stepSize;
			}
			
			float len = length(v);
			//Быстрое насыщение цвета
			v = lerp(float3(len, len, len), v, _Saturation / 100);
			v.xyz *= _Color.xyz * .01;
			
			#ifdef CLAMPOUT
				v = clamp(v, float3(0,0,0), _Color.xyz);
			#endif
			o.Emission = float3(v * .01);
		}
		
		
		
		ENDCG
	
	}

	Fallback Off
}
