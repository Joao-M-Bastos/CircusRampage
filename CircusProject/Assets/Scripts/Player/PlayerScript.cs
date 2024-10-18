using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    #region JumpValues
    [SerializeField] float _jumpForce;
    [SerializeField] float _baseCoyoteTime, _baseJumpBuffer;
    float _coyoteTime, _jumpBuffer;
    #endregion

    #region References
    [SerializeField]LayerMask _groundLayerMask;

    PlayerInput _playerInput;
    InputAction _walkAction;
    InputAction _jumpAction;
    Rigidbody _playerRB;
    #endregion

    #region Delegates
    public delegate void OnPlayerDie();
    public static OnPlayerDie onPlayerDie;
    #endregion

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
        _walkAction = _playerInput.actions.FindAction("Move");
        _jumpAction = _playerInput.actions.FindAction("Jump");

    }

    private void FixedUpdate()
    {
        HandleTimes();
        Movement();
    }

    private void HandleTimes()
    {
        CheckGround();
        if (_jumpAction.IsPressed())
        {
            _jumpBuffer = _baseJumpBuffer;
        }

        _coyoteTime -= Time.deltaTime;
        _jumpBuffer -= Time.deltaTime;
    }

    private void Movement()
    {
        Vector3 Velocity = Walk();

        Jump();

        Velocity = HandleGravity(Velocity);

        _playerRB.velocity = Velocity;
    }

    
    private Vector3 Walk()
    {
        Vector3 ScreenVelocity = Vector3.right * GameManager.Instance.ScreenSpeed * Time.deltaTime;
        Vector3 InputVelocity = _walkAction.ReadValue<Vector2>() * ScreenVelocity;

        return ScreenVelocity + InputVelocity;

        //return Vector3.zero;
    }

    private void Jump()
    {
        if (_coyoteTime <= 0 || _jumpBuffer <= 0)
            return;

        _coyoteTime = 0;
        _jumpBuffer = 0;

        _playerRB.velocity = Vector3.zero;
        _playerRB.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }

    public void CheckGround()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 1.1f, _groundLayerMask))
        {
            _coyoteTime = _baseCoyoteTime;
        }
    }

    private Vector3 HandleGravity(Vector3 velocity){

        velocity.y = _playerRB.velocity.y;

        if (!_jumpAction.IsPressed() && velocity.y > -1)
        {
            _jumpBuffer = 0;
            velocity.y = -1;
        }

        return velocity;
    }
}
