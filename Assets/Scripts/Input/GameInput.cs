using System;
using UnityEngine;

public static class GameInput {
  public static InputActions InputActions;

  #region Player Input Events
  public static event Action<Vector2> PlayerPointEvent = delegate { };
  public static event Action<Vector2> PlayerMoveEvent = delegate { };
  public static event Action PlayerInteractEvent = delegate { };
  public static event Action PlayerInventoryEvent = delegate { };
  public static event Action PlayerPauseEvent = delegate { };
  public static event Action PlayerJumpStartedEvent = delegate { };
  public static event Action PlayerJumpCanceledEvent = delegate { };
  public static event Action PlayerMoveDigitalLeftEvent = delegate { };
  public static event Action PlayerMoveDigitalRightEvent = delegate { };
  #endregion

  static GameInput() {
    InputActions = new InputActions();
    RegisterInputActionsEvents();

    EnablePlayerInput();
  }

  public static void EnablePlayerInput() {
    InputActions.Player.Enable();
    Debug.Log("Input: Movement enabled");
  }

  public static void DisablePlayerInput() {
    InputActions.Player.Disable();
    Debug.Log("Input: disabled");
  }

  static void RegisterInputActionsEvents() {
    InputActions.Player.Point.started +=
      (context) => PlayerPointEvent.Invoke(context.ReadValue<Vector2>());
    InputActions.Player.Point.performed +=
      (context) => PlayerPointEvent.Invoke(context.ReadValue<Vector2>());
    InputActions.Player.Point.canceled +=
      (context) => PlayerPointEvent.Invoke(context.ReadValue<Vector2>());

    InputActions.Player.Move.started +=
      (context) => PlayerMoveEvent.Invoke(context.ReadValue<Vector2>());
    InputActions.Player.Move.performed +=
      (context) => PlayerMoveEvent.Invoke(context.ReadValue<Vector2>());
    InputActions.Player.Move.canceled +=
      (context) => PlayerMoveEvent.Invoke(context.ReadValue<Vector2>());

    InputActions.Player.Jump.started += (_) => PlayerJumpStartedEvent.Invoke();
    InputActions.Player.Jump.canceled += (_) => PlayerJumpCanceledEvent.Invoke();

    InputActions.Player.Interact.canceled += (_) => PlayerInteractEvent.Invoke();
    InputActions.Player.Inventory.canceled += (_) => PlayerInventoryEvent.Invoke();
    InputActions.Player.Pause.canceled += (_) => PlayerPauseEvent.Invoke();

    InputActions.Player.DigitalLeft.canceled += (_) => PlayerMoveDigitalLeftEvent();
    InputActions.Player.DigitalRight.canceled += (_) => PlayerMoveDigitalRightEvent();
  }
}
