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
<<<<<<< HEAD
    /*void OnCollisionEnter(Collision collision) {
=======
    void OnCollisionEnter(Collision collision)
    {
	    Debug.Log("name : " + collision.gameObject.name);
>>>>>>> 8a484c36479b2116bed39cadb15ce82759af7f09
        if(collision.transform.tag == "Button") {
            button.click();
			if(!audio.isPlaying){
				audio.Play();
			}
        }
    }*/
}
