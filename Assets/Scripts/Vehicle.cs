using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
  [SerializeField] float relativeVelocity;

  //  float velocity
  void Start() {
    relativeVelocity = Random.Range(-0.8f, -1.2f);
  }

  // Update is called once per frame
  void FixedUpdate() {
    transform.Translate(new Vector3(
      0,
      relativeVelocity + VehicleManager.globalVelocity,
      0
    ) * Time.deltaTime);
  }
}
