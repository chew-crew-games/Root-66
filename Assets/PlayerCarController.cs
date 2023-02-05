using System;
using UnityEngine;

public class PlayerCarController : MonoBehaviour {
  public static event Action CrashedCarEvent = delegate { };

  [SerializeField] float horizontalSpeed = 2f;
  Vector2 movement;

  Animator animator;

  void Start() {
    animator = GetComponent<Animator>();
    GameInput.PlayerMoveEvent += OnMove;
  }

  // Update is called once per frame
  void FixedUpdate() {
    if (
      (movement.x > 0 && transform.position.x > 2)
      || (movement.x < 0 && transform.position.x < -2)
    ) {
      // player is trying to move beyond the road boundary
      return;
    }
    // Also update the parent street's position
    transform.Translate(new Vector3(
      movement.x * horizontalSpeed * Time.deltaTime,
      0,
      0
    ), Space.World);
  }
  void OnMove(Vector2 newMovement) {
    movement = newMovement;
  }

  void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag != "Vehicle") {
      return;
    }
    Destroy(other.gameObject);
    animator.Play("Car spin");
    CrashedCarEvent.Invoke();
  }
}
