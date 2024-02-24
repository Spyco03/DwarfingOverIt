using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private float rollSpeed;
    public float slowUrRoll = 1;
    public float moveSpeed;
    private float hMove;
    public GameObject obj;
    public Rigidbody2D rb;
    private bool touchingFloor;


    void Update()
    {

        rollSpeed = rb.velocity.x / slowUrRoll;
        hMove = Input.GetAxis("Horizontal");
        obj.transform.eulerAngles = new Vector3(
            obj.transform.eulerAngles.x,
            obj.transform.eulerAngles.y,
            obj.transform.eulerAngles.z - rollSpeed);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Floor"))
        { 
            touchingFloor = true;
        }
        else 
        { 
            touchingFloor = false;
        }
    }

        private void FixedUpdate()
    {
        if (touchingFloor)
        {
            rb.AddForce(new Vector2(moveSpeed * hMove, 0) * Time.deltaTime);
        }
    }

}
