using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squish : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { player.transform.position = respawnPoint.transform.position; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            player.transform.position = respawnPoint.transform.position;
            Debug.Log("Squish");
        }
    }
}
