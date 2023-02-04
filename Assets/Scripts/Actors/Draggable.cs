using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging;
    private Rigidbody2D rb;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMouseDown() {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        isDragging = true;
    }

    public void OnMouseUp() {
        rb.isKinematic = false;
        isDragging = false;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - transform.position);
        Vector2 pos = transform.position;
        rb.AddForce((mousePosition - pos) * 100);
    }
    
    void Update() {
        if (isDragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Vector2 currPosition = transform.position;
            rb.MovePosition(currPosition + mousePosition * Time.deltaTime * 50);
        }
    }
}
