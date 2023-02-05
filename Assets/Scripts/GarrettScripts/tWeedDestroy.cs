using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tWeedDestroy : MonoBehaviour
{
    public GameObject cubePrefab;

    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
       
        m_Rigidbody.AddForce(Vector3.back * m_Thrust);
    }


}