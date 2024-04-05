using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzl : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public GameObject form;
    bool finish;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) 
        {   move = true;
            mousePos = Input.mousePosition;
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }
    private void OnMouseUp()
    {
        move = false;
        if(Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 5f &&
            Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 5f)
        {
            this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            finish = true;
            WinScript.AddElement();
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (move == true && finish == false)
        {
            mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);    
        }
    }
}
