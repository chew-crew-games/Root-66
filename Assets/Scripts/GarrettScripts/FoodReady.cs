using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodReady : MonoBehaviour
{
    void OnTriggerStay(Collider col)
    {

        Debug.Log("Enter");

        if (col.gameObject.tag == "Carrot Smoothie")
        {
            Debug.Log("This is an Carrot Smoothie!");
            var block = GameObject.FindWithTag("Carrot Smoothie");
            Destroy(block);

        }
        if (col.gameObject.tag == "Taro Smoothie")
        {
            Debug.Log("This is a Taro Smoothie!");
        }
        if (col.gameObject.tag == "Carrot Sticks")
        {
            Debug.Log("This is a Carrot Sticks!");
        }


        if (col.gameObject.tag == "Green Machine")
        {
            Debug.Log("This is a Green Machine!");
        }
        if (col.gameObject.tag == "Root Beer")
        {
            Debug.Log("This is a Root Beer!");
        }
        
        if (col.gameObject.tag == "Tate's Signature Soup")
        {
            Debug.Log("This is an Tate's Signature Soup!");
            var block = GameObject.FindWithTag("Tate's Signature Soup");
            Destroy(block);

        }

    }
}
