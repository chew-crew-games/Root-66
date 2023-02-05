using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour {
  public static float throwForce = 100f;

  bool isDragging;
  bool isTouching;
  Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    if (isDragging) {
      Vector3 pos = GetMouseWorldPos(Mouse.current.position.ReadValue());
      // if (pos.x < -13.5f) {
      //   pos.x = -13.5f;
      // }
      // if (pos.x > 13.5f) {
      //   pos.x = 13.5f;
      // }
      // if (pos.y < -5.5f) {
      //   pos.y = -5.5f;
      // }
      // if (pos.y > 5.5f) {
      //   pos.y = 5.5f;
      // }
      rb.MovePosition(transform.position + (pos - transform.position) * Time.deltaTime * 10);
    }
  }

  void OnMouseDown() {
    rb.velocity = Vector3.zero;
    rb.isKinematic = true;
    isDragging = true;
  }

  void OnMouseUp() {
    if(!isTouching) {
      transform.parent.Find("Text").gameObject.SetActive(false);
    }
    isDragging = false;
    rb.isKinematic = false;
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
