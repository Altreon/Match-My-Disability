using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorScript : MonoBehaviour
{
    public Animation anim;
    public AnimationClip openDoorElevator;
    public AnimationClip ClosenDoorElevator;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.clip = openDoorElevator;
            anim.Play();
        }
        
        if(Input.GetKeyDown(KeyCode.N))
        {
            anim.clip = ClosenDoorElevator;
            anim.Play();
        }
    }
}
