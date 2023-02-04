using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    // Start is called before the first frame update


    private Vector3 mousePos;
    private Vector3 objectPos;
    public GameObject yourPrefab;


    private void Update()
    {

        OnMouseDown();

    }

    public void OnMouseDown()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        Instantiate(yourPrefab, objectPos, Quaternion.identity);
    }
    
}
