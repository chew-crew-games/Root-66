using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCarController : MonoBehaviour {
  [SerializeField] float horizontalSpeed = 2f;
  Vector2 movement;

  Animator animator;

  public static int currentScore = 0;
  public static int health = 3;
  [SerializeField] TMP_Text scoreComponent;
  [SerializeField] TMP_Text healthComponent;

  void Start() {
    animator = GetComponent<Animator>();
    GameInput.PlayerMoveEvent += OnMove;
    healthComponent.text = $"Health: {health}";
    scoreComponent.text = $"Score: {currentScore}";
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
    AddHealth(-1);
  }

  public void AddPoints(int earnedPoints)
    {
        currentScore += earnedPoints;
        scoreComponent.text = $"Score: {currentScore}";
    }

  public void AddHealth(int healthDiff)
    {
        health += healthDiff;
        healthComponent.text = $"Health: {health}";
    }
}
