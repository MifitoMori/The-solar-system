using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinClick : MonoBehaviour
{
    int fullEl = 12;
    public static int myEl;
    
    public GameObject winPanel;
    public GameObject button;
    public GameObject txt;
    // Update is called once per frame
    void Update()
    {
        if (fullEl == myEl)
        {
            winPanel.SetActive(true);
            button.SetActive(false);
            txt.SetActive(false);
        }
        
    }

    public static void AddElement()
    {
        myEl++;
    }
}
