using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour {
  public static event Action<VehicleManager.Lane> CarMissedEvent = delegate { };

  [SerializeField] Transform vehicleSpawn;
  void OnCollisionEnter(Collision col) {
    if (col.gameObject.tag == "Vehicle") {
      CarMissedEvent.Invoke(col.gameObject.GetComponent<Vehicle>().lane);
    }
    Destroy(col.gameObject);
  }
}
