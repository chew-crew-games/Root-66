using UnityEngine;

public class RoadLines : MonoBehaviour {
  Animator animator;
  [SerializeField] float animationAcceleration = 50f;
  [SerializeField] float minAnimationSpeed = 0.5f;

  void Start() {
    animator = GetComponent<Animator>();
  }

  void FixedUpdate() {
    animator.speed = Mathf.Max(
        -VehicleManager.globalVelocity * animationAcceleration
    );
  }
}
