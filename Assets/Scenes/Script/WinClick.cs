using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinClick : MonoBehaviour
{
    int fullEl = 13;
    public static int myEl;
    
    public GameObject winPanel;
    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (fullEl == myEl)
        {
            winPanel.SetActive(true);
            button.SetActive(false);

        }
        
    }

    public static void AddElement()
    {
        myEl++;
    }
}
