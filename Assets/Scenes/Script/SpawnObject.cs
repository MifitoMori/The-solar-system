using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObject : MonoBehaviour
{
    public GameObject objectt;
    float izmen = 0;
    public float pribav;
    public Vector2 spavnVal;
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
        Vector2 spavnPos = new Vector2(spavnVal.x, spavnVal.y + izmen);
        Instantiate(objectt, spavnPos, Quaternion.identity);
        izmen += pribav ;
        WinClick.AddElement();
    }


}

