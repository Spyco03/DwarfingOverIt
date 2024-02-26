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
    [SerializeField]
    private Canvas canvas;

    private Vector2 mousePos;
    private Vector3 cursorPos;
    public bool visible = false;
    public bool buildmode = false;

    valueSaver _valueSaver;
    private void Awake()
    {
        _valueSaver = GameObject.Find("Reasorces").GetComponent<valueSaver>();
    }

    

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cursorPos = new Vector3 (Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), -1);

        transform.position = cursorPos;

        RaycastHit2D rayHit = Physics2D.Raycast(cursorPos, Vector2.zero, Mathf.Infinity, layerMask);

        if (rayHit.collider != null || _valueSaver.materials <= 0) 
        {
            sprite.color = new Color(255, 0, 0);
        }
        else
        {
            sprite.color = new Color(255, 255, 255);
        }

        if (Input.GetMouseButton(0) && buildmode && _valueSaver.materials >= 1)
        {
            

            if (rayHit.collider == null)
            {
                Instantiate(placedblock, transform.position, Quaternion.identity);
                _valueSaver.materials--;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {   
                visible = !visible;
                buildmode = !buildmode;            
        }

        sprite.enabled = visible;

        canvas.gameObject.SetActive(visible);

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
