using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public AudioClip pickSound;
    private AudioSource audioSource;
    private Vector3 center;
    private float sizeX;
    private float sizeZ;
    private Animator animator;
    public GameObject pickUp;
    public GameObject pointsDisplay;
    public TimerBehaviour timer;
   // private GameObject[] instances;
    private int points = 0;
    private bool doubled = false;


    void Start(){
        audioSource = GetComponent<AudioSource>();
        GameObject spawn = GameObject.Find("Spawn Area");
        Collider spawnCollider = spawn.GetComponent<Collider>();
        center = spawnCollider.bounds.center;
        sizeX = spawnCollider.bounds.size.x;
        sizeZ = spawnCollider.bounds.size.z;
        animator = GetComponent<Animator>();
        pointsDisplay.GetComponent<Text>().text = "Points: "+points;
    }
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Pick Up")) {  
            Destroy(other.gameObject);                                
            audioSource.PlayOneShot(pickSound, 1F);             
            points++;
            pointsDisplay.GetComponent<Text>().text = "Points: "+points;
            animator.speed+=0.1f;
            respawn();
        }
    }       
     
    void respawn(){
        float randomX = Random.Range(center.x-sizeX/2, center.x+sizeX/2);
        float randomZ = Random.Range(center.z-sizeZ/2, center.z+sizeZ/2);
        Instantiate(pickUp, new Vector3(randomX, 1, randomZ), Quaternion.identity);

        if(doubled==false && timer.getSeconds()<=20 ){
            Instantiate(pickUp, new Vector3(randomX, 1, randomZ), Quaternion.identity);
            doubled = true;
        }
    } 
}

/*
int countPickUpInstances()
     {  
        instances = GameObject.FindGameObjectsWithTag ("Pick Up");
        return instances.Length;
     }*/