using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{   
    public Rigidbody rb;

    public float rotateSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void Update () 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetTrigger("TriggerAndamento");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetTrigger("TriggerParado");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            //GetComponent<Animator>().SetTrigger("TriggerLeft");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            //GetComponent<Animator>().SetTrigger("TriggerLeft");
        }
    }

}
