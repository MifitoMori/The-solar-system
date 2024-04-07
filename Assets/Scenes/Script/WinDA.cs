using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDA : MonoBehaviour
{
    public static int myEl;
    public GameObject Win;
    public GameObject Form;
    public GameObject Button;
    public GameObject Prav;

    // Update is called once per frame
    void Update()
    {

    }
    public void Pokas()
    {
        if (myEl == 8)
        {        
            Form.SetActive(false);
            Button.SetActive(false);
            Prav.SetActive(false);
            Win.SetActive(true);

        }

    }

    private void OnMouseUp()
    {

    }

    public static void AddElement()
    {
        myEl++;

    }
}
