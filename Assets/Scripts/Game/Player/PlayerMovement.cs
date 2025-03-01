using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
   private Rigidbody2D _rigidbody;
   private Vector2 _movementInput;
   private Vector2 _smoothMovementInput;
   private Vector2 _smoothInputMovementVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _smoothMovementInput = Vector2.SmoothDamp(
            _smoothMovementInput,
            _movementInput,
            ref _smoothInputMovementVelocity,
            0.1f
        );

        _rigidbody.linearVelocity = _smoothMovementInput * _speed;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

}
