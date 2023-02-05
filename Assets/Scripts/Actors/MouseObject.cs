using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

using UnityEngine;

public class MouseObject : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position = GetMouseWorldPos(Mouse.current.position.ReadValue());
    }

    Vector3 GetMouseWorldPos(Vector2 pointerPosition) {
    return Camera.main.ScreenToWorldPoint(new Vector3(
      pointerPosition.x,
      pointerPosition.y,
      Camera.main.WorldToScreenPoint(transform.position).z
    ));
  }
}
