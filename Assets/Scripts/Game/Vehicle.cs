using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {
  public string[] recipe;

  [SerializeField] float relativeVelocity;
  [SerializeField] float actualVelocity;

  void Start() {
    relativeVelocity = UnityEngine.Random.Range(-0.01f, -0.4f);
  }

  void FixedUpdate() {
    actualVelocity = relativeVelocity + VehicleManager.globalVelocity;
    transform.Translate(new Vector3(
      0,
      0,
      actualVelocity
    ) * Time.deltaTime);
  }

  void OnCollisionEnter(Collision col) {
    if (col.transform.tag == "Smoothie") {
      Array.Sort(recipe);
      var smoothieContents = col.transform.GetComponent<Smoothie>().contents;
      smoothieContents.Sort();
      bool matches = true;
      if (smoothieContents.Count == recipe.Length) {
        for (int x = 0; x < smoothieContents.Count; x++) {
          if (smoothieContents[x].name != recipe[x]) {
            matches = false;
          }
        }
      } else {
        matches = false;
      }
      if (matches) {
        //logic for score increase
      } else {
        //logic for health decrease
      }
      // Debug.Log("recipe");
      // foreach (string ingredient in recipe) {
      //   Debug.Log(ingredient);
      // }
      // Debug.Log("smoothie");
      // foreach (string ingredient in smoothieContents) {
      //   Debug.Log(ingredient);
      // }
    }
  }
}
