using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction _jumpAction;
    [SerializeField] private InputAction _moveAction;

    [SerializeField] private float _jumpForce;

    [SerializeField] private float _playersMovementSpeed;

    [SerializeField] private Transform _downPointLeft;
    [SerializeField] private Transform _downPointRight;

    private float _playersMovementDirection = 0;

    private float _rayDistance = 0.1f;

    private bool _isSecondJumpUse = false;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _jumpAction.performed += OnJumpButtonClick;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnEnable()
    {
        _jumpAction.Enable();
        _moveAction.Enable();
    }

    public void OnDisable()
    {
        _jumpAction.Disable();
        _moveAction.Disable();
    }

    private void OnJumpButtonClick(InputAction.CallbackContext context)
    {
        Jump();
    }

    private void Move()
    {
        _playersMovementDirection = _moveAction.ReadValue<float>();

        //Moving player using player rigid body.

        _rb.velocity =
            new Vector2(_playersMovementDirection * _playersMovementSpeed, _rb.velocity.y);
    }



    public void Jump()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(_downPointLeft.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D hitRight = Physics2D.Raycast(_downPointRight.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));


        if  (hitRight.collider != null || hitLeft.collider != null && _rb.velocity.y == 0)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isSecondJumpUse = false;
        }
        else if (!_isSecondJumpUse)
        {
            var newVelosity = _rb.velocity;
            newVelosity.y = 0;
            _rb.velocity = newVelosity;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isSecondJumpUse = true;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Land();
        }
    }

    private void Land()
    {
        _isSecondJumpUse = false;
    }
}
