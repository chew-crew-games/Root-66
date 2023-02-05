using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour {
  [SerializeField] GameObject prop;
  [SerializeField] List<GameObject> obstacles = new List<GameObject>();
  [SerializeField]
  Transform spawnLocation;


  // Start is called before the first frame update
  void Start() {
    InvokeRepeating("SpawnProp", 1, 3);
  }
  void SpawnProp() {
    float randomNumber = Random.Range(-10f, 10f);
    randomNumber = randomNumber > 0 ? randomNumber + 10 : randomNumber - 10;

    Vector3 newSpawnLocation = new Vector3(
      spawnLocation.position.x + randomNumber,
      spawnLocation.position.y + 1,
      spawnLocation.position.z
    );
    Instantiate(
      prop,
      newSpawnLocation,
      spawnLocation.rotation
    );
  }
}
