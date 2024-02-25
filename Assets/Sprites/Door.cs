using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    [SerializeField]
    private string nextLevel;

    SpriteRenderer sprite;
    public bool doorActive;

    private void Start()
    {
        sprite = GameObject.Find("Door Arrow").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.enabled = doorActive;

        if (doorActive && Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(nextLevel);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorActive = true;
            //Debug.Log("DoorActive");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        doorActive = false;
    }



}
