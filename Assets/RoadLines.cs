using UnityEngine;

public class RoadLines : MonoBehaviour {
  Animator animator;
  private float minRoadAnimationSpeed = 0.9f; // I just picked some values that felt reasonable, but these can be tweaked
  private float maxRoadAnimationSpeed = 1.2f;
  private float slope;

  void Start() {
    animator = GetComponent<Animator>();
  }

  void FixedUpdate() {
    // slope maps vehicle min/max velocity range to the animation speed min/max range
    slope = (maxRoadAnimationSpeed - minRoadAnimationSpeed) / (VehicleManager.minVelocity - VehicleManager.maxVelocity);
    animator.speed = minRoadAnimationSpeed + (slope * VehicleManager.globalVelocity);
  }
}
