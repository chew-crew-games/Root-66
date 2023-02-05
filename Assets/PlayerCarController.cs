using System;
using UnityEngine;

public class PlayerCarController : MonoBehaviour {
  public static event Action<VehicleManager.Lane> CrashedCarEvent = delegate { };

  [SerializeField] float horizontalSpeed = 2f;
  Vector2 movement;

  Animator animator;


  DashboardItemsController dic;



  public AudioClip[] sounds;
  public AudioSource source;
  void Start() {

    animator = GetComponent<Animator>();
    dic = transform.Find("Dashboard").Find("Items").GetComponent<DashboardItemsController>();
    GameInput.PlayerMoveEvent += OnMove;
  }

  // Update is called once per frame
  void FixedUpdate() {
    if (
      (movement.x > 0 && transform.position.x > 2)
      || (movement.x < 0 && transform.position.x < -2)
    ) {
      // player is trying to move beyond the road boundary
      return;
    }
    // Also update the parent street's position
    transform.Translate(new Vector3(
      movement.x * horizontalSpeed * Time.deltaTime,
      0,
      0
    ), Space.World);
  }
  void OnMove(Vector2 newMovement) {
    movement = newMovement;
  }

  void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag != "Vehicle") {
      return;
    }
    VehicleManager.Lane lane = other.gameObject.GetComponent<Vehicle>().lane;
    CrashedCarEvent.Invoke(lane);
    Debug.Log("Destroying: " + other.gameObject.name);
    Destroy(other.gameObject);

    animator.Play("Car spin");
    dic.GenerateForces();

    // source.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
    // source.Play();
    animator.Play("Car spin");

  }
}
