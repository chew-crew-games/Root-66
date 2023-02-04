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
    GameInput.PlayerMoveDigitalLeftEvent += () => OnPressDirection(true);
    GameInput.PlayerMoveDigitalRightEvent += () => OnPressDirection(false);
    GameInput.PlayerMoveEvent += OnMove;
  }

  void Update() {

  }

  void FixedUpdate() {
    // globalVelocity += accelerationStatus * acceleration;
    // Debug.Log(globalVelocity);
  }

  void OnMove(Vector2 movement) {
    accelerationStatus * movement.y;
    Debug.Log(accelerationStatus);
  }

  //   float CalcGlobalVelocity() {


  // if (accelerationStatus > 0) {
  //   globalVelocity += acceleration;
  // } else if(accelerationStatus < 0) {
  //     globalVelocity += (accelerationStatus)
  // }
  //   }

  void OnPressDirection(bool isLeft) {
    var currentPosition = parentStreet.transform;
    var num = isLeft ? 1 : -1;

    if (isLeft) {
      if (objectPosition == 1) {
        return;
      }
      objectPosition += 1;
    } else {
      if (objectPosition == -1) {
        return;
      }
      objectPosition -= 1;
    }

    parentStreet.transform.Translate(num * horizontalDistance, 0, 0, Space.World);
    Debug.Log("translating: " + num);
  }
}
