using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour {
  Rigidbody rb;
  [SerializeField] float initialVelocity = -20f;
  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    rb.velocity = new Vector3(
      0,
      0,
      initialVelocity + VehicleManager.globalVelocity
    );
  }
}
