using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerBehaviour : MonoBehaviour
{
    public GameObject timerDisplay;
    public GameObject centralDisplay;
    public int seconds = 30;
    public bool countingDown = false;
    void Start()
    { 
        if(seconds<10){
            timerDisplay.GetComponent<Text>().text = "00:0" + seconds;
        }
        else{
            timerDisplay.GetComponent<Text>().text = "00:" + seconds;
        }
    }

    IEnumerator timer(){
        countingDown = true;
        yield return new WaitForSeconds(1);
        if(seconds<10){
            timerDisplay.GetComponent<Text>().text = "00:0" + seconds;
        }
        else{
            timerDisplay.GetComponent<Text>().text = "00:" + seconds;
        }
        seconds--;
        countingDown = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(countingDown==false && seconds>=0){
            StartCoroutine(timer());
        }
        if(seconds == -1){
            GetComponent<AnimationTriggers>().enabled = false;
            GetComponent<PlayerBehaviour>().enabled = false;
            GetComponent<Animator>().SetTrigger("TriggerParado");
            centralDisplay.GetComponent<Text>().text = "GAME OVER";
        }
    }

    public int getSeconds(){
        return seconds;
    }
}
