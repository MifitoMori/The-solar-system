using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulescales : MonoBehaviour
{
    public GameObject popUpPanel;

    void Start()
    {
        // Скрываем окно при запуске
        popUpPanel.SetActive(false);
    }

    void Update()
    {
        // Проверяем нажатие на экран
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию касания
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Проверяем, попало ли касание в область всплывающего окна
            if (popUpPanel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(popUpPanel.GetComponent<RectTransform>(), touchPos, Camera.main))
            {
                // Если касание было за пределами окна, скрываем его
                popUpPanel.SetActive(false);
            }
        }
    }

    public void OpenClosePopUpWindow()
    {
        // Открываем или закрываем окно при нажатии кнопки
        popUpPanel.SetActive(!popUpPanel.activeSelf);
    }
}
