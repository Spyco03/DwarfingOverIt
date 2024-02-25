using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeParticle : MonoBehaviour
{
    [SerializeField]
    private GameObject _object;
    [SerializeField]
    private GameObject particle1;
    [SerializeField]
    private GameObject particle2;
    [SerializeField]
    private GameObject rot;

    public AudioSource speaker;
    public AudioClip[] clips;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            AudioClip audioClip = clips[Random.Range(0, clips.Length - 1)];
            speaker.clip = audioClip;
            speaker.Play();
            Spawn();
        }

    }

    public void Spawn()
    {
        if (rot.transform.eulerAngles.z <= 89 || rot.transform.eulerAngles.z >= 271) 
        {
            Instantiate(_object, particle1.transform.position, Quaternion.identity);
            
        }
        else if (rot.transform.eulerAngles.z >= 91 && rot.transform.eulerAngles.z <= 269)
        {
            Instantiate(_object, particle2.transform.position, Quaternion.identity);
            
        }


    }
}
