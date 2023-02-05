using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour {
  public enum Lane {
    Left = -1,
    Middle = 1,
    Right = 3
  }

  [SerializeField] List<GameObject> vehicles = new List<GameObject>();
  [SerializeField] float acceleration = 2f;
  public static float minVelocity = -7f;
  public static float maxVelocity = 1f;

  public Dictionary<Lane, string[]> dict = new Dictionary<Lane, string[]>();

  string[] ingredients = new string[] { "potato", "taro", "carrot" };

  [SerializeField] Transform spawnLocation;
  [SerializeField] Transform carParent;
  [SerializeField] GameObject carPrefab;

  Vector2 movement;

  public static float globalVelocity;

  void Start() {
    GameInput.PlayerMoveEvent += (vector) => OnPressDirection(vector);
    globalVelocity = -2f;

    InvokeRepeating("TrySpawnCar", 4, 4);
  }

  void FixedUpdate() {
    // Broadcast new velocity to all other vehicles
    globalVelocity = Mathf.Clamp(
      globalVelocity + -movement.y * acceleration,
      minVelocity,
      maxVelocity
    );
  }

  void TrySpawnCar() {
    if (dict.Count >= 2) {
      return;
    }

    Lane lane;
    System.Random random = new System.Random();
    Array lanes = Enum.GetValues(typeof(Lane));
    do {
      lane = (Lane)lanes.GetValue(random.Next(lanes.Length));
    } while (dict.ContainsKey(lane));

    Debug.Log("Lane: " + lane);

    string[] recipe = new string[UnityEngine.Random.Range(1, 3)];
    for (int index = 0; index < recipe.Length; index++) {
      recipe[index] = ingredients[UnityEngine.Random.Range(0, ingredients.Length - 1)];
    }
    Debug.Log("Created new car with recipe: " + string.Join(" ", recipe));

    dict.Add(lane, recipe);
    GameObject newCar = Instantiate(
      carPrefab,
      new Vector3(
        spawnLocation.position.x + (float)lane,
        spawnLocation.position.y,
        spawnLocation.position.z
      ),
      spawnLocation.rotation
    );
    newCar.GetComponent<Vehicle>().recipe = recipe;
    newCar.transform.parent = carParent;
  }

  void OnPressDirection(Vector2 lastMovement) {
    // Change velocity
    movement = lastMovement;
  }
}
