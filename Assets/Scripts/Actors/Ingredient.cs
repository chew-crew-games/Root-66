using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public void OnMouseDown() {
        gameObject.layer = 6;
    }

    public void OnMouseUp() {
        gameObject.layer = 0;
    }
}
