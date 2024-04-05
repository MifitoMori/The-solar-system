using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Delete : MonoBehaviour
{
    public GameObject[] spawnedObjects;
    public Text textComponent;
    public float displayTime = 5f; // Время отображения в секундах
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                DeleteObj();
                SpawnObjectOnTouch.CountL = 0;
                SpawnObjectOnTouch.CountR = 0;
                Show();

            }
        }
    }

    void DeleteObj()
    {
        spawnedObjects = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject spawnedObject in spawnedObjects)
        {
            Destroy(spawnedObject);
        }

    }
    void Show()
    {
        textComponent.text = "Чаши очищены!";

        Invoke("HideText", displayTime);

    }
    void HideText()
    {
        textComponent.text = "";
    }
}
