using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour {
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
    Debug.Log("made it");
    Debug.Log(other.gameObject.tag);
    if (other.gameObject.tag == "Vehicle") {
      Destroy(other.gameObject);
      animator.Play("Car spin");
    }
  }

}
