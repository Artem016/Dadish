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

    float _playersMovementDirection = 0;

    float _rayDistance = 0.1f;

    bool _isSecondJumpUse = false;
    bool _isMove;

    Rigidbody2D _rb;
    
    PlayerAnimationController _animController;

    PlayerAudioController _audioController;

    private void Awake()
    {
        _jumpAction.performed += OnJumpButtonClick;
        _rb = GetComponent<Rigidbody2D>();
        _animController = GetComponent<PlayerAnimationController>();
        _audioController = GetComponent<PlayerAudioController>();
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
            _audioController.Run();
            _isMove = true;
        }
        else if(moveVector.x == 0 && _isMove)
        {
            _animController.StopRun();
            _audioController.StopRun();
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
            _audioController.Jump();
            _isSecondJumpUse = false;
        }
        else if (!_isSecondJumpUse)
        {
            var newVelosity = _rb.velocity;
            newVelosity.y = 0;
            _rb.velocity = newVelosity;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _animController.Jump();
            _audioController.Jump();
            _isSecondJumpUse = true;
        }
            
    }

    public void Stop()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        if(_audioController.IsRun)
            _audioController.StopRun();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Land();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (_audioController.IsRun)
            {
                _audioController.StopRun();
            }
        }
    }

    private void Land()
    {
        _isSecondJumpUse = false;
        _animController.Landing();
        if(!_audioController.IsRun && _isMove)
        {
            _audioController.Run();
        }
    }
}
