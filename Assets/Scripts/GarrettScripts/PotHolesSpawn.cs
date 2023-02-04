using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotHolesSpawn : MonoBehaviour
{

    [SerializeField] GameObject[] potHolePrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HolesSpawn());
    }

    IEnumerator HolesSpawn()
    {

        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(potHolePrefab[Random.Range(0, potHolePrefab.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);

        }

    }
}
