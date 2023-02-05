using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] prefabs;

    private int randomPrefab;
    public GameObject objectToSpawn1;
    public GameObject objectToSpawn3;
    public GameObject objectToSpawn2;

    IEnumerator Start()
    {
       yield return new WaitForSeconds(15f);
        StartCoroutine(thirdExampleCoroutine());
        yield return new WaitForSeconds(20f);

        
    }

    IEnumerator thirdExampleCoroutine()
    {
        
                randomPrefab = Random.Range(0,3);
                Instantiate(prefabs[randomPrefab], transform.position, transform.rotation, transform);
                yield return new WaitForSeconds(23f);
                StartCoroutine(thirdExampleCoroutine());
    }
   
}
