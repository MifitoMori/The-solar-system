using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class preretask : MonoBehaviour
{
    bool move;
    float startPosX;
    float startPosY;
    public GameObject form;
    bool finish;
    private Vector3 reset;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            move = true;
        }
    }
    private void OnMouseUp()
    {
        move = false;
        if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            WinDA.AddElement();
        }
        else
        {
            this.transform.localPosition = new Vector3(reset.x, reset.y, reset.z);
        }
    }
    void Start()
    {
        reset = this.transform.localPosition;
    }
    void Update()
    {
        if (move == true && finish == false)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosX, this.gameObject.transform.localPosition.z);
        }
    }
}
