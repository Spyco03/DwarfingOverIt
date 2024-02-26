using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valueSaver : MonoBehaviour
{
    public int materials;
    public int collectables;
    public AudioSource speaker;
    public AudioClip pickupSound;

    public void CollectSound()
    {
        speaker.clip = pickupSound;
        speaker.volume = 0.5f;
        speaker.pitch = 1.5f;
        speaker.Play();

    }
}
