using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] prefabs;

    private int randomPrefab;

    IEnumerator Start()
    {
        StartCoroutine(ExampleCoroutine());
        yield return new WaitForSeconds(20f);

        StartCoroutine(secCoroutine());
        yield return new WaitForSeconds(20f);

        StartCoroutine(thirdCoroutine());
        yield return new WaitForSeconds(20f);
    }

    IEnumerator ExampleCoroutine()
    {
        
                randomPrefab = Random.Range(0,3);
                Instantiate(prefabs[randomPrefab], new Vector3(-4.72f, 3.07f,0), Quaternion.identity);
                yield return new WaitForSeconds(23f);
                StartCoroutine(ExampleCoroutine());
    }
    IEnumerator secCoroutine()
    {

        randomPrefab = Random.Range(0, 3);
        Instantiate(prefabs[randomPrefab], new Vector3(-2f, 3.04f, 0), Quaternion.identity);
        yield return new WaitForSeconds(23f);
        StartCoroutine(secCoroutine());
    }
    IEnumerator thirdCoroutine()
    {

        randomPrefab = Random.Range(0, 3);
        Instantiate(prefabs[randomPrefab], new Vector3(.67f, 3.07f, 0), Quaternion.identity);
        yield return new WaitForSeconds(23f);
        StartCoroutine(thirdCoroutine());
    }
}
