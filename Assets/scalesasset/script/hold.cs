using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hold : MonoBehaviour
{
    private Vector3 offset;
    private float distanceFromCamera; // ���������� �� ������ �� �������

    void OnMouseDown()
    {
        distanceFromCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition; // �������� ���������� ����
        mousePoint.z = distanceFromCamera; // ������ ���������� �� ������ �� �������
        return Camera.main.ScreenToWorldPoint(mousePoint); // ��������� �������� ���������� � �������
    }
}

