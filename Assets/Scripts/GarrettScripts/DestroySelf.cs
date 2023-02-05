using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
