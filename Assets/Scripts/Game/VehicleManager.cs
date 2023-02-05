using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VehicleManager : MonoBehaviour {
  public static event Action<int> RecipeScoreUpdate = delegate { };
  public static event Action<int> HealthUpdate = delegate { };

  public struct Order {
    public string[] recipe;
    public GameObject gameObject;

    public Order(string[] newRecipe, GameObject newGameObject) {
      recipe = newRecipe;
      gameObject = newGameObject;
    }
  }

  public enum Lane {
    Left = -1,
    Middle = 1,
    Right = 3
  }

  [SerializeField] List<GameObject> vehicles = new List<GameObject>();
  [SerializeField] float acceleration = 2f;
  public static float minVelocity = -20f;
  public static float maxVelocity = 1f;

  public static Dictionary<Lane, Order> orders = new Dictionary<Lane, Order>();

  string[] ingredients = new string[] { "Potato", "Taro", "Carrot" };

  [SerializeField] Transform spawnLocation;
  [SerializeField] Transform carParent;
  [SerializeField] GameObject carPrefab;
  [SerializeField] Ticket ticketPrefab;
  [SerializeField] GameObject dashboard;

  Vector2 movement;

  public static float globalVelocity;

  void Start() {
    GameInput.PlayerMoveEvent += (vector) => OnPressDirection(vector);
    globalVelocity = -2f;
    Vehicle.CarDeletedEvent += OnCarDeleted;
    PlayerCarController.CrashedCarEvent += OnCrashedCar;
    DeathBox.CarMissedEvent += (lane) => OnCarDeleted(lane, false);
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
    if (orders.Count >= 2) {
      return;
    }

    Lane lane;
    System.Random random = new System.Random();
    Array lanes = Enum.GetValues(typeof(Lane));
    do {
      lane = (Lane)lanes.GetValue(random.Next(lanes.Length));
    } while (orders.ContainsKey(lane));

    string[] recipe = new string[UnityEngine.Random.Range(1, 3)];
    for (int index = 0; index < recipe.Length; index++) {
      recipe[index] = ingredients[UnityEngine.Random.Range(0, ingredients.Length - 1)];
    }

    Ticket newTicket = Instantiate(
      ticketPrefab,
      dashboard.transform.position + new Vector3(
        UnityEngine.Random.Range(-.3f, .3f),
        0.95f,
        0f
      ),
      dashboard.transform.rotation);
    newTicket.transform.name = "Ticket";
    newTicket.transform.parent = dashboard.transform;
    newTicket.SetRecipe(recipe);
    Debug.Log("Created new car with recipe: " + string.Join(" ", recipe));

    orders.Add(lane, new Order(recipe, newTicket.gameObject));
    Debug.Log("Added key: " + lane);

    GameObject newCar = Instantiate(
      carPrefab,
      new Vector3(
        spawnLocation.position.x + (float)lane,
        spawnLocation.position.y,
        spawnLocation.position.z
      ),
      spawnLocation.rotation
    );
    Vehicle vehicle = newCar.GetComponent<Vehicle>();
    vehicle.recipe = recipe;
    vehicle.lane = lane;
    newCar.transform.parent = carParent;
  }

  void OnCrashedCar(Lane lane) {
    Debug.Log(lane);
    Destroy(orders[lane].gameObject);
    orders.Remove(lane);
  }

  void OnCarDeleted(Lane lane, bool success) {
    if (success) {
      RecipeScoreUpdate.Invoke(10);
    } else {
      HealthUpdate.Invoke(-1);
    }
    Debug.Log(lane);
    Destroy(orders[lane].gameObject);
    orders.Remove(lane);
  }

  void OnPressDirection(Vector2 lastMovement) {
    // Change velocity
    movement = lastMovement;
  }
}
