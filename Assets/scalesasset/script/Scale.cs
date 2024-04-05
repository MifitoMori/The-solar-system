using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public Transform leftBowl;
    public Transform rightBowl;

    void Update()
    {
        // ������� ��������� ����� �������� � �����
        float leftWeight = CalculateWeight(leftBowl);
        float rightWeight = CalculateWeight(rightBowl);

        // ����������� ������� ���� ����� ������
        float weightDifference = leftWeight - rightWeight;

        // ��������� ���� �������� ����� � ����������� �� �������
        float angle = Mathf.Clamp(weightDifference, -45f, 45f);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    float CalculateWeight(Transform bowl)
    {
        float totalWeight = 0f;
        Collider2D[] colliders = bowl.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            totalWeight += collider.GetComponent<Rigidbody2D>().mass;
        }
        return totalWeight;
    }
}
