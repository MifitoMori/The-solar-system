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
        private Vector2 reset;
        public GameObject myPuzzl;
        


        private void Start()
        {
            reset = transform.localPosition;
            finish = false;           
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
                        
            if (!finish && Math.Abs(this.transform.position.x - form.transform.position.x) <= 3f &&
               Math.Abs(this.transform.position.y - form.transform.position.y) <= 10f)
            {
                this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y);   
                finish = true;
            }           
            else
            {
                this.transform.localPosition = new Vector2(reset.x, reset.y);
                finish = false;
            }
            IsFinished();
                        
        }
        
        void IsFinished()
        {
            if (Math.Abs(this.transform.position.x - form.transform.position.x) == 0f &&
               Math.Abs(this.transform.position.y - form.transform.position.y) == 0f)
            {
                WinScript.AddElement(myPuzzl);
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


