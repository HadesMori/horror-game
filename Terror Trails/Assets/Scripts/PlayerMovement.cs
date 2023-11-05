using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }


    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        rb.velocity = direction * speed * Time.fixedDeltaTime;
    }
}
