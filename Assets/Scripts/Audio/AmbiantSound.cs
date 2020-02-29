using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiantSound : MonoBehaviour
{
    public AudioClip clip;
    public bool autoStart = true;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(-3f, 3f)]
    public float pitch = 1f;
    
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.spatialBlend = 0f;

        if(autoStart){
            audioSource.Play();
        }

        audioSource.volume = volume;
        audioSource.pitch = pitch;

        PlaySound();
    }

    public void PlaySound () {
        audioSource.Play();
        audioSource.PlayOneShot(clip);
    }

    public void StopSound () {
        audioSource.Stop();
    }
}
