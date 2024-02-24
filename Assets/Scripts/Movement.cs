using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private float rollSpeed;
    public float slowUrRoll = 1;
    public float PickaxeRoll = 3;
    public float moveSpeed;
    private float hMove;
    public GameObject obj;
    public Rigidbody2D rb;
    private bool touchingFloor;
    public Vector2 boxSize;
    public float castDist;
    public LayerMask ground;


    void Update()
    {

        rollSpeed = rb.velocity.x / slowUrRoll;
        hMove = Input.GetAxis("Horizontal");
        obj.transform.eulerAngles = new Vector3(
            obj.transform.eulerAngles.x,
            obj.transform.eulerAngles.y,
            obj.transform.eulerAngles.z - rollSpeed);
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.collider.CompareTag("Floor"))
    //    {
    //        Vector3 normal = other.GetContact(0).normal;
    //        if (normal == Vector3.up)
    //        {
    //            touchingFloor = true;
    //        }
    //    }
    //    else 
    //    {
    //        Debug.Log("In Air");
    //        touchingFloor = false;
    //    }
    //}

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDist, ground))
        {
            return true;
        }
        else { return false; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position- transform.up * castDist, boxSize);
    }


    private void FixedUpdate()
    {
        if (isGrounded())
        {
            rb.AddForce(new Vector2(moveSpeed * hMove, 0) * Time.deltaTime);
            //Debug.Log("Floor");
        }
        else
        {
            rb.AddForce(new Vector2((moveSpeed / PickaxeRoll) * hMove, 0) * Time.deltaTime);
            //Debug.Log("Air");
        }
    }

}
