using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public AudioClip pickSound;
    private AudioSource audioSource;

    private Random random = new Random();

    private Vector3 origin;


    public int speed = 5;

    private GameObject spawn;
    private Collider spawnCollider;

    private Vector3 center;
    private float sizeX;
    private float sizeZ;

    private Animator animator;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        spawn = GameObject.Find("Spawn Area");
        spawnCollider = spawn.GetComponent<Collider>();
        center = spawnCollider.bounds.center;
        sizeX = spawnCollider.bounds.size.x;
        sizeZ = spawnCollider.bounds.size.z;
        animator = GetComponent<Animator>();

    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Pick Up")) {
            audioSource.PlayOneShot(pickSound, 1F); 
            float randomX = Random.Range(center.x-sizeX/2, center.x+sizeX/2);
            float randomZ = Random.Range(center.z-sizeZ/2, center.z+sizeZ/2);
            Instantiate(other.gameObject, new Vector3(randomX, 1, randomZ), other.transform.rotation);
            Destroy(other.gameObject);
            animator.speed+=0.1f;
        }
    }

 
}
