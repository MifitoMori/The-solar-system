using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sbros : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject button;
    public GameObject txt;
    public GameObject k1;
    public GameObject k2;
    public GameObject k3;
    public GameObject k4;
    public GameObject k5;
    public GameObject k6;
    public GameObject k7;
    public GameObject k8;
    public GameObject k9;
    public GameObject k10;
    public GameObject k11;
    public GameObject k12;
    public GameObject k13;
    public void sbrosBut()
    {
            winPanel.SetActive(false);
            button.SetActive(true);
            txt.SetActive(true);
            WinClick.myEl = 0;
        k1.SetActive(false);
        k2.SetActive(false);
        k3.SetActive(false);
        k4.SetActive(false);
            k5.SetActive(false);
        k6.SetActive(false);
        k7.SetActive(false);
        k8.SetActive(false);
        k9.SetActive(false);
        k10.SetActive(false);
        k11.SetActive(false);
        k12.SetActive(false);
        k13.SetActive(false);
        SpawnObject.count = 1; 
    }
}
