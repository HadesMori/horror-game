using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runMultiplier;
    [SerializeField] private KeyCode _runButton = KeyCode.LeftShift;
    private bool _canMove;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _direction;

    void Start()
    {
        CanMove();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetDirection();
    }


    void FixedUpdate()
    {
        if (_canMove)
        {
            Move();
            Run();
        }
    }

    private void SetDirection()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private Vector2 Move()
    {
        _rb.velocity = _direction * _speed * Time.fixedDeltaTime;

        _animator.SetFloat("Horizontal", _direction.x);
        _animator.SetFloat("Vertical", _direction.y);
        _animator.SetFloat("Speed", _direction.magnitude);

        if (_direction.x == 1 || _direction.x == -1 || _direction.y == 1 || _direction.y == -1)
        {
            _animator.SetFloat("LastX", _direction.x);
            _animator.SetFloat("LastY", _direction.y);
        }
        return _rb.velocity;
    }

    private void Run()
    {
        if (Input.GetKey(_runButton)){
            _rb.velocity = Move() * _runMultiplier;
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    private void Stop()
    {
        _rb.velocity = Vector2.zero;
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", 0);
        _animator.SetFloat("Speed", 0);
        _canMove = false;
    }

    private void CanMove()
    {
        _canMove = true;
    }

    public void SwitchMoveState()
    {
        if (_canMove)
        {
            Stop();
        }
        else
        {
            CanMove();
        }
    }

}
