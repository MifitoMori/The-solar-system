using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawnObjectOnTouch : MonoBehaviour
{
    public Text textComponent;
    public float displayTime = 5f; // ����� ����������� � ��������
    public GameObject objectToSpawn; // ������, ������� ����� ����������
    public Transform spawnPointL; // ����� ������ �������
    public Transform spawnPointR; // ����� ������ �������
    public int wich;
    public static int CountL = 0;
    public static int CountR = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                SpawnObject();
            }
        }
    }

    void SpawnObject()
    {
        if (wich == 1)
        {
            if (CountL < 3)
            {
                Instantiate(objectToSpawn, spawnPointL.position, Quaternion.identity);
                CountL++;
            }

            else
                Show();

        }
        else
        {
            if (CountR < 3)
            { 
                Instantiate(objectToSpawn, spawnPointR.position, Quaternion.identity);
                CountR++;
            }
            else
                Show();
        }

    }
    void Show()
    {
        textComponent.text = "�� ������ 3 ������ �� ���� ����";
        Invoke("HideText", displayTime);

    }
    void HideText()
    {
        textComponent.text = "";
    }
}
