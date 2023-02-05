using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItems : MonoBehaviour
{
    public Transform spawnPoint;//Add empty gameobject as spawnPoint
    public float minHeightForDeath;
    public GameObject item; //Add your player

    void Update()
    {
        if (item.transform.position.y < minHeightForDeath)
            item.transform.position = spawnPoint.position;
    }
}
