using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeParticle : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            Spawn();
        }

    }

    public void Spawn()
    {
        Instantiate(_object, transform.position, Quaternion.identity);
    }
}
