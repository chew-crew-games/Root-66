using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject cubePrefab;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject()
    {
       

            Vector3 randomSpawnPosition = new Vector3(Random.Range(-5, -8), 1, Random.Range(111, 115));
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(13f);

    }

  
}

