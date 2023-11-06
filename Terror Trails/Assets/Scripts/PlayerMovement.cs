using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float runMultiplier;
    [SerializeField] private KeyCode runButton = KeyCode.LeftShift;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 direction;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private Vector2 Move()
    {
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        return rb.velocity;
    }

    private void Run()
    {
        if (Input.GetKey(runButton)){
            rb.velocity = Move() * runMultiplier;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void SetAnimatorParameters()
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.magnitude);

        if (direction.x == 1 || direction.x == -1 || direction.y == 1 || direction.y == -1)
        {
            animator.SetFloat("LastX", direction.x);
            animator.SetFloat("LastY", direction.y);
        }
    }
}
