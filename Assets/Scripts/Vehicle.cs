using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
  [SerializeField] float relativeVelocity;
  [SerializeField] float actualVelocity;

  //  float velocity
  void Start() {
    relativeVelocity = Random.Range(-0.01f, -0.4f);
  }

  // Update is called once per frame
  void FixedUpdate() {
    actualVelocity = relativeVelocity + VehicleManager.globalVelocity;
    transform.Translate(new Vector3(
      0,
      actualVelocity,
      0
    ) * Time.deltaTime);
  }
}
