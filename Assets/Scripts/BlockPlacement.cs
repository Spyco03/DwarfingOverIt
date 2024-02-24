using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class BlockPlacement : MonoBehaviour
{
    [SerializeField]
    private UnityEvent disablepick;
    [SerializeField]
    private UnityEvent enablepick;

    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private GameObject placedblock;
    [SerializeField]
    private LayerMask layerMask;

    private Vector2 mousePos;
    private Vector2 cursorPos;
    public bool visible = false;
    public bool buildmode = false;


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cursorPos = new Vector2 (Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        transform.position = cursorPos;

        if (Input.GetMouseButton(0) && buildmode)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(cursorPos, Vector2.zero, Mathf.Infinity, layerMask);

            if (rayHit.collider == null)
            {
                Instantiate(placedblock, transform.position, Quaternion.identity);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E Pressed");
            
                visible = !visible;
                buildmode = !buildmode;
            
        }

        sprite.enabled = visible;

        if (buildmode)
        {
            disablepick?.Invoke();
        }
        else
        {
            enablepick?.Invoke();
        }

    }


}
