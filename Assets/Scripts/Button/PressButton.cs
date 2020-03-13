using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    public UnityEvent clickEvent;

    AudioSource audio;

    void Start () {
		audio = GetComponent<AudioSource>();
    }
    
    public void click () {
		Debug.Log("button click");
        if(!audio.isPlaying){
			audio.Play();
		}
        clickEvent.Invoke();
    }
}
