using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider : MonoBehaviour
{
    [SerializeField] private Slider volume;
    public void ChangerVolume()
    {
        AudioListener.volume = volume.value;
    }
}
