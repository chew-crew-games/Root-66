using System;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour {
  [SerializeField] List<GameObject> vehicles = new List<GameObject>();
  [SerializeField] GameObject parentStreet;
  [SerializeField] float horizontalDistance = 2f;
  [SerializeField] float acceleration = 2f;

  int objectPosition = 0;
  float accelerationStatus = 0;

  public static float globalVelocity = 0;

  void Start() {
    GameInput.PlayerMoveEvent += (vector) => OnPressDirection(vector);
  }

  void Update() {

  }

  void FixedUpdate() {
    globalVelocity += accelerationStatus * acceleration;
  }

  void OnPressDirection(Vector2 movement) {
    // Change velocity
    accelerationStatus = -movement.y;

    if (Mathf.Abs(movement.x) == 1) {
      // Move street left and right
      if (movement.x > 0) {
        if (objectPosition == 1) {
          return;
        }
        objectPosition += 1;
      } else if (movement.x < 0) {
        if (objectPosition == -1) {
          return;
        }
        objectPosition -= 1;
      } else {
        return;
      }

      parentStreet.transform.Translate(movement.x * -1 * horizontalDistance, 0, 0, Space.World);
    }
  }
}
