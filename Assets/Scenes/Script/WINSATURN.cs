using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WINSATURN : MonoBehaviour
{
    // Start is called before the first frame update
    int fullElement;
    public static int myElement;
    public GameObject myPuzzl;
    public GameObject myPanel;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        myElement = 0;
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
