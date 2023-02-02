using UnityEngine;

[RequireComponent(typeof(Actor))]
public abstract class ActorController : MonoBehaviour {
  [HideInInspector] public Vector2 moveInput;

  protected Actor _actor;

  protected virtual void Start() {
    _actor = GetComponent<Actor>();
  }

  protected abstract void Destroy();
}
