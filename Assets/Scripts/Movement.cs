using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    private float hMove;

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    void Update()
    {
        hMove = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveSpeed*hMove, rb.velocity.y);

    }


}
