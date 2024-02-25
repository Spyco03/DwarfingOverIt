using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            Debug.Log("Squish");
        }
    }
}
