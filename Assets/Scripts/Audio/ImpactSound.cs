using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public SurfaceSound sounds;

    AudioSource audioSource;
    public float minVelocity = 0.000001f;
    public float maxVelocity = 10f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter (Collision collision) {
        float velocity = collision.relativeVelocity.magnitude;

        if(velocity < minVelocity){
            return;
        }else if(velocity > maxVelocity){
            velocity = maxVelocity;
        }

        AudioClip clip = sounds.clips[Random.Range(0, sounds.clips.Length)];

        audioSource.PlayOneShot(clip, velocity / maxVelocity);
    }
}
