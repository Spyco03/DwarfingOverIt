using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickaxe : MonoBehaviour
{
    //This code was modified from orignally https://www.youtube.com/watch?v=-bkmPm_Besk&ab_channel=MoreBBlakeyyy

    private Camera mainCamera;
    private Vector3 mousePos;
    public float smooth = 10.0f;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        Quaternion target = Quaternion.Euler(0, 0, rotZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    

}