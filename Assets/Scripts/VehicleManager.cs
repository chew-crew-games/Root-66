using System;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour {
  [SerializeField] List<GameObject> vehicles = new List<GameObject>();
  [SerializeField] GameObject parentStreet;
  [SerializeField] float horizontalSpeed = 3f;
  [SerializeField] float acceleration = 2f;

  int objectPosition = 0;
  float accelerationStatus = 0;

  Vector2 movement;

  public static float globalVelocity = 0;

  void Start() {
    GameInput.PlayerMoveEvent += (vector) => OnPressDirection(vector);
  }

  void Update() {

  }

  void FixedUpdate() {
    // Broadcast new velocity to all other vehicles
    globalVelocity += -movement.y * acceleration;

    // Also update the parent street's position
    parentStreet.transform.Translate(new Vector3(
      movement.x * -1 * horizontalSpeed * Time.deltaTime,
      0,
      0
    ), Space.World);
  }

  void OnPressDirection(Vector2 lastMovement) {
    // Change velocity
    movement = lastMovement;
  }
}
