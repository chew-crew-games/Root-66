using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTurn : MonoBehaviour
{
    // Start is called before the first frame update
    public int velocidade = 500;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * velocidade * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * velocidade * Time.deltaTime);

        }

    }
}
