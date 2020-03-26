using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private bool cupIsPresent = false;
    private bool buttonHasBeenPressed = false;
    [SerializeField] private AudioSource cafe;
    [SerializeField] private AudioClip cafeClip;
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject particlesCoffeeMaker;
    //[SerializeField] private OVRGrabber toActivateAtEnd;
    private setObjectif objSetter;
    private bool objDone = false;
    private void Start()
    {
        cafe = gameObject.GetComponent<AudioSource>();
        objSetter = gameObject.GetComponent<setObjectif>();
    }

    public void SetCupIsPresent()
    {
        cupIsPresent = true;
    }

    public void ButtonPressed()
    {
        Debug.Log("pressed");
        if (cupIsPresent && !cafe.isPlaying)
        {
            if(!buttonHasBeenPressed && !objDone)
            {
                Debug.Log("OK");
                buttonHasBeenPressed = true;
                cafe.PlayOneShot(cafeClip);
                StartCoroutine(waitForEndOfSound(true));
            }else if (objDone)
            {
                cafe.PlayOneShot(cafeClip);
                StartCoroutine(waitForEndOfSound(false));
            }
        }
    }

    IEnumerator waitForEndOfSound(bool setObj)
    {
        particlesCoffeeMaker.SetActive(true);
        while (cafe.isPlaying)
        {
            yield return null;

        }
        particlesCoffeeMaker.SetActive(false);
        if(setObj)
            setThisObjectif();
    }

    private void setThisObjectif()
    {
        particles.SetActive(true);
        objSetter.Set();
        objDone = true;
    }
}
