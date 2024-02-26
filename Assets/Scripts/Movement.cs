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
    public Vector2 boxSize;
    public float castDist;
    public LayerMask ground;
    public AudioSource speaker;

    

    void Update()
    {

        rollSpeed = rb.velocity.x / slowUrRoll;
        hMove = Input.GetAxis("Horizontal");
        obj.transform.eulerAngles = new Vector3(
            obj.transform.eulerAngles.x,
            obj.transform.eulerAngles.y,
            obj.transform.eulerAngles.z - rollSpeed);
    }

    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDist, ground))
        {
            return true;
        }
        else { return false;}
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
            rb.AddForce(new Vector2( moveSpeed * hMove, 0) / PickaxeRoll * Time.deltaTime );
            //Debug.Log("Air");
        }
        
        if (rollSpeed >= 1 || rollSpeed <= -1) 
        {
            speaker.UnPause();
            //Debug.Log("shmovin");
        }
        else
        {
            speaker.Pause();
        }

    }

}
