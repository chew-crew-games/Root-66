using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
  [SerializeField] float relativeVelocity;
  [SerializeField] float actualVelocity;

  //  float velocity
  void Start() {
    relativeVelocity = Random.Range(-1f, -1.3f);
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
