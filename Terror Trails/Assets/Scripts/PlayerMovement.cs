using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _runMultiplier;
    [SerializeField] private KeyCode _runButton = KeyCode.LeftShift;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _direction;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetDirection();
        SetAnimatorParameters();
    }


    void FixedUpdate()
    {
        Move();
        Run();
    }

    private void SetDirection()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private Vector2 Move()
    {
        _rb.velocity = _direction * _speed * Time.fixedDeltaTime;
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

    private void SetAnimatorParameters()
    {
        _animator.SetFloat("Horizontal", _direction.x);
        _animator.SetFloat("Vertical", _direction.y);
        _animator.SetFloat("Speed", _direction.magnitude);

        if (_direction.x == 1 || _direction.x == -1 || _direction.y == 1 || _direction.y == -1)
        {
            _animator.SetFloat("LastX", _direction.x);
            _animator.SetFloat("LastY", _direction.y);
        }
    }
}
