using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    PressButton button;
	
	AudioSource audio;

    void Start () {
        button = transform.parent.GetComponent<PressButton>();
		audio = GetComponent<AudioSource>();
    }
    /*void OnCollisionEnter(Collision collision) {
    {
	    Debug.Log("name : " + collision.gameObject.name);
        if(collision.transform.tag == "Button") {
            button.click();
			if(!audio.isPlaying){
				audio.Play();
			}
        }
    }*/
}
