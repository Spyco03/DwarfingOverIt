using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Collectable : MonoBehaviour
{
    valueSaver _valueSaver;


    [SerializeField]
    private GameObject self;
    private void Start()
    {
        _valueSaver = GameObject.Find("Reasorces").GetComponent<valueSaver>();
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _valueSaver.CollectSound();
        _valueSaver.collectables++;
        Destroy(self);
    }
}
