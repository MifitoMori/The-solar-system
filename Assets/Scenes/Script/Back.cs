using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public int sceneNum;
   public void BackMenu()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
