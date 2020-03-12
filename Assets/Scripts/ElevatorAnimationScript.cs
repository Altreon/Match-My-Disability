﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorAnimationScript : MonoBehaviour
{
    [SerializeField] private Animation anim;

    public AnimationClip openDoorElevatorAnimation;
    public AnimationClip ClosenDoorElevatorAnimation;

    private bool m_isDoorOpen = false;
    public SceneControler m_sceneControler;

    public void OpenDoor()
    {
        if (!m_isDoorOpen && !anim.isPlaying)
        {
            Debug.Log("Door will open");
            m_isDoorOpen = true;
            anim.clip = openDoorElevatorAnimation;
            anim.Play();
            StartCoroutine(WaitForAnimationEnd(-1));
        }
        else
        {
            Debug.Log("Door is already opened");
        }
    }


    public void CloseDoor(int levelIndex)
    {
        if (m_isDoorOpen && !anim.isPlaying)
        {
            Debug.Log("Door will close");
            m_isDoorOpen = false;
            anim.clip = ClosenDoorElevatorAnimation;
            anim.Play();
            StartCoroutine(WaitForAnimationEnd(levelIndex));
        }
        else
        {
            Debug.Log("Door is already closed");
        }
    }


    IEnumerator WaitForAnimationEnd(int levelIndex)
    {
        while (anim.isPlaying)
            yield return null;
        if (levelIndex >= 0)
        {
            m_sceneControler.LoadLevelCoroutine(levelIndex);
            OpenDoor();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OpenDoor();
        }
        
        if(Input.GetKeyDown(KeyCode.N))
        {
            CloseDoor(1);
        }

    }
}
