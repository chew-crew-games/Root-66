using System;
using UnityEngine;

public class DeathBox : MonoBehaviour {
  public static event Action<VehicleManager.Lane> CarMissedEvent = delegate { };

  [SerializeField] Transform vehicleSpawn;
  void OnCollisionEnter(Collision col) {
    if (col.gameObject.tag == "Ground") return;
    Debug.Log(col.gameObject.name);
    if (col.gameObject.tag == "Vehicle") {
      CarMissedEvent.Invoke(col.gameObject.GetComponent<Vehicle>().lane);
    }
    Debug.Log("Destroying: " + col.gameObject.name);

    Destroy(col.gameObject);
  }
}
