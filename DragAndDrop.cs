using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool isDragging;
    Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    void FixedUpdate()
    {
        if(isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rig.MovePosition(rig.position + mousePos );
            //transform.Translate(mousePos);
        }
    }

   // private void OnCollisionEnter2D(Collision2D collision)
   // {
       // isDragging = false;
   // }
}
