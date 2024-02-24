using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BreakableBlock : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _hit;

    [SerializeField]
    private GameObject _object;

    public float strength = 2f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Break Blocks"))
        {
            if (strength <= 0f)
            {
                _hit.Invoke();
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
