using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool m_isLevelButtonPressed = false;
    private bool m_isDoorOpen = false;
    private bool m_isQuit;
    //private bool m_isPressed = false;

    public void ButtonPressed(string button)
    {
        switch (button)
        {
            case "levelOneButton":
                if (m_isLevelButtonPressed) return;
                Debug.Log("sceneName to load: 'LevelOne'");
                m_isLevelButtonPressed = true;
                SceneManager.LoadScene("LevelOne");
                return;
            case "levelTwoButton":
                if (m_isLevelButtonPressed) return;
                Debug.Log("sceneName to load: 'LevelTwo'");
                m_isLevelButtonPressed = true;
                SceneManager.LoadScene("LevelTwo");
                return;
            case "DoorButton":
                
            default:
                Debug.Log("Button invalid");
                return;
        }
    }

    private void AnimationDoor()
    {
        if (!m_isDoorOpen)
        {
            Debug.Log("Door will open");
            m_isDoorOpen = true;
        }
        else
        {
            Debug.Log("Door will close");
            m_isDoorOpen = false;
        }
    }

}


