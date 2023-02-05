using System;
using UnityEngine;

public class Vehicle : MonoBehaviour {
  public static event Action<VehicleManager.Lane, bool> CarDeletedEvent = delegate { };

  public string[] recipe;
  public VehicleManager.Lane lane;

  // [SerializeField] float relativeVelocity;
  [SerializeField] float relativeVelocity = -0.2f;
  [SerializeField] float actualVelocity;


  void Start() {
    // relativeVelocity = UnityEngine.Random.Range(-0.01f, -0.4f);
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
      Debug.Log(!col.gameObject.GetComponent<Smoothie>().isInCar);
      Debug.Log(col.gameObject.GetComponent<Smoothie>().isInCar);

      if (!col.gameObject.GetComponent<Smoothie>().isInCar) {
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
        CarDeletedEvent.Invoke(lane, matches);
        Destroy(col.transform.parent.gameObject);
        Destroy(gameObject);
        Debug.Log("destroyed");
      }
    }
  }
}
