using System;
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
    private bool _isMove;

    private Rigidbody2D _rb;

    PlayerAnimationController _animController;

    private void Awake()
    {
        _jumpAction.performed += OnJumpButtonClick;
        _rb = GetComponent<Rigidbody2D>();
        _animController = GetComponent<PlayerAnimationController>();
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
        if(_playersMovementDirection != 0)
            transform.localScale = new Vector3(Math.Sign(_playersMovementDirection), transform.localScale.y, transform.localScale.z);
        //Moving player using player rigid body.

        var moveVector = new Vector2(_playersMovementDirection * _playersMovementSpeed, _rb.velocity.y);

        if (moveVector.x != 0 && !_isMove)
        {
            _animController.Run();
            _isMove = true;
        }
        else if(moveVector.x == 0 && _isMove)
        {
            _animController.StopRun();
            _isMove = false;
        }


        _rb.velocity = moveVector;
            
    }



    public void Jump()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(_downPointLeft.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D hitRight = Physics2D.Raycast(_downPointRight.position, Vector2.down, _rayDistance, LayerMask.GetMask("Ground"));


        if  (hitRight.collider != null || hitLeft.collider != null && _rb.velocity.y == 0)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animController.Jump();
            _isSecondJumpUse = false;
        }
        else if (!_isSecondJumpUse)
        {
            var newVelosity = _rb.velocity;
            newVelosity.y = 0;
            _rb.velocity = newVelosity;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animController.Jump();
            _isSecondJumpUse = true;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Land();
        }
    }

    private void Land()
    {
        _isSecondJumpUse = false;
        _animController.Landing();
    }
}
