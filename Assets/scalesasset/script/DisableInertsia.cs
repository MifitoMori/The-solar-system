using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInertsia : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
        void FixedUpdate()
    {
        // ��������� �������� �� ��� X
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // ���������, ���� �� ������������ � ������ ��������
        if (col.gameObject.tag == "AnotherObject" || col.gameObject.tag == "Planet" )
        {
            // �������� �������� ������� ��� �������������� �������
            rb.velocity = Vector3.zero;
        }
    }
}
