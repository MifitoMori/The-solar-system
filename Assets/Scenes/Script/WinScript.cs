using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement;
    public static int myElement;
    public GameObject myPuzzl;
    public GameObject myPanel;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        fullElement = myPuzzl.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (fullElement == myElement)
        {
            myPanel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}
