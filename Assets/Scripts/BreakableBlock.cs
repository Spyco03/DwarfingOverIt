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
    [SerializeField]
    private Sprite[] matSprite;
    [SerializeField]
    private Sprite[] baseSprite;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public AudioClip breakSound;

    valueSaver _valueSaver;

    public float strength = 2f;
    public bool mats;

    private void Start()
    {
        _valueSaver = GameObject.Find("Reasorces").GetComponent<valueSaver>();
        if (mats)
        {
            _spriteRenderer.sprite = matSprite[Random.Range(0, matSprite.Length -1)];
        }
        else
        {
            _spriteRenderer.sprite = baseSprite[Random.Range(0, baseSprite.Length - 1)];
        }
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
