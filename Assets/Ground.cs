using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
  public static event Action<int> LitteringFine = delegate { };
  [SerializeField] Transform ingredientSpawn;
  [SerializeField] Transform blenderSpawn;
  public void OnCollisionEnter(Collision col) {
    if (col.gameObject.tag == "Ingredient") {
      col.transform.position = ingredientSpawn.position;
      col.transform.rotation = ingredientSpawn.rotation;
      col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    } else if (col.gameObject.tag == "Blender") {
      col.transform.position = blenderSpawn.position;
      col.transform.rotation = blenderSpawn.rotation;
      col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    } else {
      Destroy(col.gameObject);
    }
    LitteringFine.Invoke(-2);
  }
}
