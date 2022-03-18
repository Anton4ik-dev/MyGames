using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    private Collider2D col;
    private Camera cam;
    private bool isBeingDragged;


    void Start()
    {
        cam = Camera.main;
        isBeingDragged = false;
        col = GetComponent<Collider2D>();
    }

    void Update()
    {

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetMouseButton(0))
        {
            Collider2D objNow = Physics2D.OverlapPoint(mousePos);
            if(col == objNow)
            {
                isBeingDragged = true;
            }

            if(isBeingDragged)
            {
                transform.position = mousePos;
            }
        } else
        {
            isBeingDragged = false;
        }
    }
}
