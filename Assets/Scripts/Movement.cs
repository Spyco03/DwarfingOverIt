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

    void Update()
    {
        rollSpeed = rb.velocity.x / slowUrRoll;
        hMove = Input.GetAxis("Horizontal");
        obj.transform.eulerAngles = new Vector3(
            obj.transform.eulerAngles.x,
            obj.transform.eulerAngles.y,
            obj.transform.eulerAngles.z - rollSpeed);
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(moveSpeed * hMove, 0) * Time.deltaTime);
    }

}
