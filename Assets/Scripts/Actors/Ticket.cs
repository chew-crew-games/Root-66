using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ticket : MonoBehaviour {
  TMP_Text text;
  public static float throwForce = .5f;

  bool isDragging;
  Rigidbody rb;
  string[] recipe;

  void Start() {
    text = transform.Find("Text").GetComponent<TMP_Text>();
    rb = GetComponent<Rigidbody>();
    text.text = FormatTicket();
    rb.maxAngularVelocity = 0.1f;
  }

  void FixedUpdate() {
    Vector3 pos = Mouse.current.position.ReadValue();
    if (isDragging) {
      rb.velocity = (GetMouseWorldPos(pos) - transform.position) * (1 / Time.deltaTime) * .5f;
    }
    Vector3 currentRotation = transform.localRotation.eulerAngles;
    if (currentRotation.z < -20f || currentRotation.z > 20f) {
      currentRotation.z = Mathf.Clamp(currentRotation.z, -20f, 20f);
      transform.localRotation = Quaternion.Euler(currentRotation);
    }
  }

  void OnMouseDown() {
    rb.angularVelocity = Vector3.zero;
    transform.rotation = Quaternion.identity;
    isDragging = true;
  }

  void OnMouseUp() {
    isDragging = false;
    Vector3 pos = GetMouseWorldPos(Mouse.current.position.ReadValue()) - transform.position;
    rb.AddForce((pos - transform.position) * throwForce);
  }

  Vector3 GetMouseWorldPos(Vector2 pointerPosition) {
    return Camera.main.ScreenToWorldPoint(new Vector3(
    pointerPosition.x,
    pointerPosition.y,
    Camera.main.WorldToScreenPoint(transform.position).z
    ));
  }

  public void SetRecipe(string[] recipeInput) {
    recipe = recipeInput;
  }

  string FormatTicket() {
    string newText = transform.name + "\n";
    foreach (string ingredient in recipe) {
      newText += ingredient + " ";
    }
    newText += "smoothie";
    return newText;
  }
}
