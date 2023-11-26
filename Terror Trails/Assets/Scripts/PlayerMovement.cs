using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runMultiplier;
    [SerializeField] private KeyCode _runButton = KeyCode.LeftShift;
    private bool canMove;
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
        if (canMove)
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

        _animator.SetFloat("Horizontal", direction.x);
        _animator.SetFloat("Vertical", direction.y);
        _animator.SetFloat("Speed", direction.magnitude);

        if (direction.x == 1 || direction.x == -1 || direction.y == 1 || direction.y == -1)
        {
            _animator.SetFloat("LastX", direction.x);
            _animator.SetFloat("LastY", direction.y);
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
        canMove = false;
    }

    private void CanMove()
    {
        canMove = true;
    }

    public void SwitchMoveState()
    {
        if (canMove)
        {
            Stop();
        }
        else
        {
            CanMove();
        }
    }

}
