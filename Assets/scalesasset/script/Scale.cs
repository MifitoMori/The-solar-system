using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public Transform leftBowl;
    public Transform rightBowl;

    void Update()
    {
        // Подсчет суммарной массы объектов в чашах
        float leftWeight = CalculateWeight(leftBowl);
        float rightWeight = CalculateWeight(rightBowl);

        // Определение разницы масс между чашами
        float weightDifference = leftWeight - rightWeight;

        // Изменение угла поворота весов в зависимости от разницы
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
