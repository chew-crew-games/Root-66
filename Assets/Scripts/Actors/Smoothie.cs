using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoothie : MonoBehaviour {
  public List<Ingredient> contents;
  public bool isInCar;

  public void checkIfInCar() {
    //dont ask
    float localX = transform.position.x - transform.parent.position.x + 0.2593872f;
    if (localX < 0.45f && localX > -0.45f) {
      isInCar = true;
    }
    else {
      isInCar = false;
    }
  }

  void Update() {
    checkIfInCar();
  }
}
