using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SignScript : MonoBehaviour
{

    public Canvas _ui;
    private bool _enabled = false;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _enabled = false;
    }

    private void FixedUpdate()
    {
        _ui.enabled = _enabled;
    }

}
