using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMachine : MonoBehaviour
{
    private bool buttonHasBeenPressed = false;
    [SerializeField] private AudioSource water;
    [SerializeField] private AudioClip waterClip;
    [SerializeField] private GameObject particles;

    void Start()
    {
        water = gameObject.GetComponent<AudioSource>();

        
    }

    public void ButtonPressed()
    {
        Debug.Log("pressed");
        if(!buttonHasBeenPressed)
        {
            buttonHasBeenPressed = true;
            water.PlayOneShot(waterClip);
            StartCoroutine(waitForEndOfSound());
            
        }
    }

    IEnumerator waitForEndOfSound()
    {
        particles.SetActive(true);
        while (water.isPlaying)
        {
            yield return null;

        }
        particles.SetActive(false);
        buttonHasBeenPressed = false;
    }
}
