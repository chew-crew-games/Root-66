using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour {
  Rigidbody rb;
  [SerializeField] float initialVelocity = -4f;
  public float viewVelocity;
  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    viewVelocity = initialVelocity + VehicleManager.globalVelocity;
    rb.velocity = new Vector3(
      0,
      0,
      initialVelocity + VehicleManager.globalVelocity
    ) * Time.deltaTime;
  }
}
