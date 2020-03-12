using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private bool cupIsPresent = false;
    private bool buttonHasBeenPressed = false;
    private AudioSource cafe;
    [SerializeField] private GameObject particles;
    [SerializeField] private OVRGrabber toActivateAtEnd;

    private void Start()
    {
        cafe = gameObject.GetComponent<AudioSource>();
    }


    public void SetCupIsPresent()
    {
        cupIsPresent = true;
    }

    public void ButtonPressed()
    {
        Debug.Log("pressed");
        if (cupIsPresent)
        {
            if(!buttonHasBeenPressed)
            {
                buttonHasBeenPressed = true;
                cafe.Play();
                StartCoroutine(waitForEndOfSound());
                
            }
        }
    }

    IEnumerator waitForEndOfSound()
    {
        while (cafe.isPlaying)
        {
            yield return null;
        }

        toActivateAtEnd.enabled = true;
        particles.SetActive(true);
        ObjectifManager.Instance.setObjectif("coffee");
    }
}
