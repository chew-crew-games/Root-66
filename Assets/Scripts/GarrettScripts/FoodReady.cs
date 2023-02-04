using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReady : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {

        Debug.Log("Enter");

        if (col.gameObject.tag == "Carrot Smoothie")
        {
            Debug.Log("This is an Carrot Smoothie!");
            var block = GameObject.FindWithTag("Carrot Smoothie");
            Destroy(block);

        }
        if (col.gameObject.tag == "Beatroot Smoothie")
        {
            Debug.Log("This is a Beatroot Smoothie!");
        }
        if (col.gameObject.tag == "Potato Smoothie")
        {
            Debug.Log("This is a Potato Smoothie!");
        }
    }
}
