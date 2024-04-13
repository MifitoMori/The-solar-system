using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    
    public static int myElement;
    public GameObject myPuzzl;
    public GameObject myPanel;
    public GameObject WinPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int placedElements = 0;
        foreach (Transform child in myPuzzl.transform)
        {
            if (child.position == child.GetComponent<MovengPuzzl>().form.transform.position)
            {
                placedElements++;
            }
        }

        if (placedElements == myPuzzl.transform.childCount)
        {
            myPanel.SetActive(false);
            WinPanel.SetActive(true);
        }
    }

    public static void AddElement(GameObject puzzle)
    {
        if (myElement < puzzle.transform.childCount)
        {
            myElement++;
        }
    }
}
