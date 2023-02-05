using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

       

        if (col.gameObject.tag == "BG")
        {
            Debug.Log("This is an no more!");
            var block = GameObject.FindWithTag("BG");
            Destroy(block);

        }
       

       

    }
}
