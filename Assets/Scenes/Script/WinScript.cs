using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullEl;
    public static int myEl;
    public GameObject myPyzzl;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        fullEl = myPyzzl.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(fullEl == myEl)
        {
            winPanel.SetActive(true);
        }
    }

    public static void AddElement()
    {
        myEl++;
    }
}
