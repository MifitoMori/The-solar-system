using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObject : MonoBehaviour
{
    public GameObject objectt;
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
    public static int count = 1;
    //float izmen = 0;
    //public float pribav;
    //public Vector2 spavnVal;
    //public GameObject spawnObject;
    //public Camera camera;
    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    Instantiate(spawnObject, camera.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward, Quaternion.identity);
        //}
    }
    public void SpawnObjects()
    {
        //Vector2 spavnPos = new Vector2(spavnVal.x, spavnVal.y + izmen);
        //Instantiate(objectt, spavnPos, Quaternion.identity);
        //izmen += pribav ;
        if (count == 1) { k1.SetActive(true); }
        if(count == 2) { k2.SetActive(true);}
        if(count == 3) { k3.SetActive(true); }
        if(count == 4) { k4.SetActive(true);}
        if(count == 5) { k5.SetActive(true);}
        if(count == 6) { k6.SetActive(true);}
        if(count == 7) { k7.SetActive(true);}
        if(count == 8) { k8.SetActive(true);}
        if(count == 9) { k9.SetActive(true);}
        if(count == 10) { k10.SetActive(true);}
        if(count == 11) { k11.SetActive(true);}
        if(count == 12) { k12.SetActive(true);}
        if(count == 13) { k13.SetActive(true);}
        count++;
        WinClick.AddElement();
    }


}

