using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour {
  public static float throwForce = .5f;

  public bool isDragging;
  bool isTouching;
  Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
    rb.maxAngularVelocity = 1f;
  }

  void FixedUpdate() {
    if (isDragging) {
      Vector3 pos = Mouse.current.position.ReadValue();
      rb.velocity = (GetMouseWorldPos(pos) - transform.position) * (1 / Time.deltaTime) * .5f;
    }
  }

  void OnMouseDown() {
    rb.angularVelocity = Vector3.zero;
    isDragging = true;
  }

  void OnMouseUp() {
    if (!isTouching) {
      transform.parent.Find("Text").gameObject.SetActive(false);
    }
    isDragging = false;
    Vector3 pos = GetMouseWorldPos(Mouse.current.position.ReadValue()) - transform.position;
    rb.AddForce((pos - transform.position) * throwForce);

  }

  void OnMouseEnter() {
    transform.parent.Find("Text").gameObject.SetActive(true);
    isTouching = true;
  }

  void OnMouseExit() {
    if (!isDragging) {
      transform.parent.Find("Text").gameObject.SetActive(false);
    }
    isTouching = false;
  }

  Vector3 GetMouseWorldPos(Vector2 pointerPosition) {
    return Camera.main.ScreenToWorldPoint(new Vector3(
      pointerPosition.x,
      pointerPosition.y,
      Camera.main.WorldToScreenPoint(transform.position).z
    ));
  }
}
