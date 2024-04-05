using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sbros : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject button;
    public GameObject txt;
    public void sbrosBut()
    {
            winPanel.SetActive(false);
            button.SetActive(true);
            txt.SetActive(true);
            WinClick.myEl = 0;
    }
}
