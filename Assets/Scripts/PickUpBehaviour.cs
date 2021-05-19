using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    public float speed= 0.5f;

   // public AudioClip pickSound;
   // private AudioSource audioSource;

    void start(){
       // audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       // audioSource.PlayOneShot(pickSound, 1F);
        transform.Rotate(speed, speed, 0, Space.World);
    }  
}
