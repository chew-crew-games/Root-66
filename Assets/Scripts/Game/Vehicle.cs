using System;
using UnityEngine;

public class Vehicle : MonoBehaviour {
  public string[] recipe;

  public static event Action<int> RecipeScoreUpdate = delegate { };

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

  void OnTriggerEnter(Collider col) {
    if (col.transform.tag == "Smoothie") {
      Array.Sort(recipe);
      LogUtils.PrintArray(recipe);
      var smoothieContents = col.transform.GetComponent<Smoothie>().contents;
      smoothieContents.Sort((ing1, ing2) => ing1.name.CompareTo(ing2.name));
      LogUtils.PrintList(smoothieContents);
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
        Debug.Log("Success!");
        RecipeScoreUpdate.Invoke(10);
      } else {
        Debug.Log("Wrong recipe!");
        RecipeScoreUpdate.Invoke(-5);
      }
      Destroy(col.gameObject);
      Destroy(gameObject);
      Debug.Log("destroyed");
    }
  }
}
