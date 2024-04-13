using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Seriatim()
    {
        SceneManager.LoadScene("Seriatim1");
    }
    public void Scales()
    {
        SceneManager.LoadScene("Scales2");
    }
    public void Comparison3()
    {
        SceneManager.LoadScene("Comparison3");
    }
    public void Group()
    {
        SceneManager.LoadScene("Group4");
    }
}
