using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{


    public GameObject CubePrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(10, 11), .2f, Random.Range(10,11));
            Instantiate(CubePrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
