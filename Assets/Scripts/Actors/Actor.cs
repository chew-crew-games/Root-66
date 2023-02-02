using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(SpriteRenderer))]
// [RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ActorController))]
public class Actor : MonoBehaviour {
  // enum AnimationState {
  //   Idle,
  //   Walk,
  //   Jump
  // }

  [Header("Movement")]
  [SerializeField] float _speed = 4;
  [SerializeField] float _acceleration = 70;
  [SerializeField] float _deceleration = 30;

  Vector2 movementVector;
  float moveAxis;
  Vector2 velocity;

  /* Components */
  ActorController _actorController;
  Rigidbody2D _rigidbody;
  // SpriteRenderer _spriteRenderer;
  // Animator _animator;
  // AnimationState _currentAnimation = AnimationState.Idle;


  void Start() {
    _actorController = GetComponent<ActorController>();
    _rigidbody = GetComponent<Rigidbody2D>();
    // _animator = GetComponent<Animator>();
    // _spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update() {
    velocity = CalculateVelocity();
  }

  void FixedUpdate() {
    _rigidbody.velocity = velocity;
  }

  Vector2 CalculateVelocity() {
    movementVector = _actorController.moveInput * _speed;
    float acc = movementVector.sqrMagnitude > 0
      ? _acceleration
      : _deceleration;

    Vector2 deltaVelocity = Vector2.MoveTowards(
      velocity,
      _speed * movementVector,
      acc * Time.deltaTime
    );

    return deltaVelocity;
  }

  // void ChangeAnimationState(AnimationState newAnimation) {
  //   if (_currentAnimation == newAnimation) return;

  //   _currentAnimation = newAnimation;
  //   _animator.Play(_currentAnimation.name + animDirection);
  //   Debug.Log("Animation state: " + _currentAnimation.name);
  // }
}
