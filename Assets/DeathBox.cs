using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {
  [SerializeField] Transform vehicleSpawn;

  void OnCollisionEnter(Collision col) {
    if (col.gameObject.tag == "Vehicle") {
      Debug.Log("Vehicle destroyed, respawning");
      Destroy(col.gameObject);
    }
  }
}
