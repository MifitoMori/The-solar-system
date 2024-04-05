using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




    public class MovengPuzzl : MonoBehaviour
    {
        bool move;
        Vector2 mousePos;
        float startPosX;
        float startPosY;
        public GameObject form;
        bool finish;
        Vector2 resetPos;

    private void Awake()
    {
        resetPos = transform.position;
    }
    void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                move = true;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;
            }
        }

        void OnMouseUp()
        {
            move = false;

            
            if (Math.Abs(this.transform.position.x - form.transform.position.x) <= 3f &&
               Math.Abs(this.transform.position.y - form.transform.position.y) <= 10f && finish != true)
            {
                this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
                finish = true;
                WinScript.AddElement();
            }
            else
        {
            transform.position = resetPos; finish = false;
        }
           
    }

        
        void Update()
        {
            if (move == true && finish == false)
            {
                mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            }
            

        }
    }


