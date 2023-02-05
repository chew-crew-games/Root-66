using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardItemsController : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 1f;
    [SerializeField] float crashSpeed = 10f;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        GameInput.PlayerMoveEvent += OnMove;
    }

    void FixedUpdate() {
        foreach(Transform child in transform) {
            child.GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3(-movement.x, 0f, 0f) * horizontalSpeed);
        }
    }

    void OnMove(Vector2 newMovement) {
        movement = newMovement;
    }

    public void GenerateForces() {
        foreach(Transform child in transform) {
            child.GetChild(0).GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-0.3f, 0.3f), 1f, 0f) * crashSpeed);
        }
    }
}
