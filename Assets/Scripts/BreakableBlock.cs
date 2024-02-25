using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class BreakableBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private GameObject self;

    
    public AudioClip breakSound;

    valueSaver _valueSaver;

    public float strength = 2f;
    public bool mats;

    private void Start()
    {
        _valueSaver = GameObject.Find("Reasorces").GetComponent<valueSaver>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Break Blocks"))
        {
            
            if (strength <= 0f)
            {
                if (mats)
                {
                    _valueSaver.materials++;
                }
                Spawn();
                AudioSource.PlayClipAtPoint(breakSound, transform.position);
                Destroy(self);
            }
            else
            {
                
                strength -= 1;
                Spawn();
            }
            
            
        }
    }

    public void Spawn()
    {
        Instantiate(_object, transform.position, Quaternion.identity);
    }

}
