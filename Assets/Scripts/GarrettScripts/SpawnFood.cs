using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour
{

    public GameObject cuber;

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            print(Input.mousePosition);
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            print(p);
            print(p.x);
            print(p.y);

            Instantiate(cuber, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);

        }
    }
}
    
