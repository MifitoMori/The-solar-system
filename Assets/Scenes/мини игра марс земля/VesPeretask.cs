using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesPeretask : MonoBehaviour
{

    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    private Vector3 reset;
    bool finish;
    public GameObject formMars;
    public GameObject formZemla;
    public GameObject spavnInMars;
    public GameObject spavnInZem;
    public GameObject vesMars;
    public GameObject vesZem;
    bool sp1;
    bool sp2;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
        }
    }
    private void OnMouseUp()
    {
        move = false;
        //if (Mathf.Abs(this.transform.localPosition.x - form1.transform.localPosition.x) <= 50f &&
        //    Mathf.Abs(this.transform.localPosition.y - form1.transform.localPosition.y) <= 50f)
        //{
        //    this.transform.position = new Vector2(form1.transform.position.x, form1.transform.position.y);
        //    Spavn2();

        //}
        if (Mathf.Abs(this.transform.localPosition.x - formZemla.transform.localPosition.x) <= 80f &&
            Mathf.Abs(this.transform.localPosition.y - formZemla.transform.localPosition.y) <= 80f)
        {
           this.transform.position = new Vector2(formZemla.transform.position.x, formZemla.transform.position.y);

           SpavnInMars();

        }
        else if (Mathf.Abs(this.transform.localPosition.x - formMars.transform.localPosition.x) <= 80f &&
            Mathf.Abs(this.transform.localPosition.y - formMars.transform.localPosition.y) <= 80f)
        {
            this.transform.position = new Vector2(formMars.transform.position.x, formMars.transform.position.y);

            SpavnInZem();

        }
        else
        {
            Sbros();
            this.transform.localPosition = new Vector3(reset.x, reset.y, reset.z);
        }
    }
    void Start()
    {
        reset = this.transform.localPosition;
    }
    void Update()
    {
        if (move == true /*&& finish == false*/)
        {
            mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }

    }
    private void SpavnInMars()
    {
        spavnInMars.SetActive(true);
        vesMars.SetActive(true);
        vesZem.SetActive(true);
    }
    private void SpavnInZem()
    {
        spavnInZem.SetActive(true);
        vesMars.SetActive(true);
        vesZem.SetActive(true);
    }
    private void Sbros()
    {
        spavnInMars.SetActive(false);
        spavnInZem.SetActive(false);
        vesMars.SetActive(false);
        vesZem.SetActive(false);
    }
}
