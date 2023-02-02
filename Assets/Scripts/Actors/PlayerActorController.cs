using UnityEngine;

public class PlayerActorController : ActorController {
  protected override void Start() {
    base.Start();

    GameInput.PlayerMoveEvent += OnMove;
  }

  protected override void Destroy() {
    GameInput.PlayerMoveEvent -= OnMove;
  }

  void OnMove(Vector2 playerMoveInput) {
    moveInput = playerMoveInput;
  }
}
