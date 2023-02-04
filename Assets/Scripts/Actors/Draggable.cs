using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
  [SerializeField] public static float throwForce = 30;

  bool isDragging;
  Rigidbody rb;

  Vector2 draggingMousePosition;
  Vector3 mOffset;

  public void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    if (isDragging) {
      rb.MovePosition(GetMouseWorldPos(draggingMousePosition) + mOffset);
    }
  }

  public void OnBeginDrag(PointerEventData eventData) {
    rb.velocity = Vector3.zero;
    rb.isKinematic = true;
    isDragging = true;

    mOffset = transform.position - GetMouseWorldPos(eventData.position);
  }

  public void OnDrag(PointerEventData eventData) {
    draggingMousePosition = eventData.position;
  }

  public void OnEndDrag(PointerEventData eventData) {
    isDragging = false;
    rb.isKinematic = false;
    rb.AddForce(eventData.delta * throwForce);
  }

  Vector3 GetMouseWorldPos(Vector2 pointerPosition) {
    return Camera.main.ScreenToWorldPoint(new Vector3(
      pointerPosition.x,
      pointerPosition.y,
      Camera.main.WorldToScreenPoint(transform.position).z
    ));
  }
}
