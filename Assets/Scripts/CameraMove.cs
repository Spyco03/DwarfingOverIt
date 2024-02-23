using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public float trackSpeed;

    public Vector3 camOffset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.position + camOffset;
        transform.position = Vector3.Lerp(transform.position, newPos, trackSpeed);
    }
}
