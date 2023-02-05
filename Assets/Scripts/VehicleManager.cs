using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour {
  [SerializeField] List<GameObject> vehicles = new List<GameObject>();
  [SerializeField] GameObject parentStreet;
  [SerializeField] float acceleration = 2f;
  [SerializeField] public static float minVelocity = -2f;
  [SerializeField] public static float maxVelocity = -0.01f;

  Vector2 movement;

  public static float globalVelocity;

  void Start() {
    GameInput.PlayerMoveEvent += (vector) => OnPressDirection(vector);
    globalVelocity = minVelocity;
  }

  void Update() {

  }

  void FixedUpdate() {
    // Broadcast new velocity to all other vehicles
    globalVelocity = Mathf.Clamp(
      globalVelocity + -movement.y * acceleration,
      minVelocity,
    maxVelocity);
  }

  void OnPressDirection(Vector2 lastMovement) {
    // Change velocity
    movement = lastMovement;
  }
}
