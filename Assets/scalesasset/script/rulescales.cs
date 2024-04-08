using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rulescales : MonoBehaviour
{
    public GameObject popUpPanel;

    void Start()
    {
        // �������� ���� ��� �������
        popUpPanel.SetActive(false);
    }

    void Update()
    {
        // ��������� ������� �� �����
        if (Input.GetMouseButtonDown(0))
        {
            // �������� ������� �������
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // ���������, ������ �� ������� � ������� ������������ ����
            if (popUpPanel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(popUpPanel.GetComponent<RectTransform>(), touchPos, Camera.main))
            {
                // ���� ������� ���� �� ��������� ����, �������� ���
                popUpPanel.SetActive(false);
            }
        }
    }

    public void OpenClosePopUpWindow()
    {
        // ��������� ��� ��������� ���� ��� ������� ������
        popUpPanel.SetActive(!popUpPanel.activeSelf);
    }
}
