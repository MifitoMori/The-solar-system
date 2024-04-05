using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hold : MonoBehaviour
{
    private Vector3 offset;
    private float distanceFromCamera; // Расстояние от камеры до объекта

    void OnMouseDown()
    {
        distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; // Получаем координаты мыши
        mousePoint.z = distanceFromCamera; // Задаем расстояние от камеры до объекта
        return Camera.main.ScreenToWorldPoint(mousePoint); // Переводим экранные координаты в мировые
    }
}

