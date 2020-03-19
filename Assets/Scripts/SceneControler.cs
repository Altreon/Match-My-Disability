using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{

    //private int m_currentScene;
    public ElevatorAnimationScript m_elevatorAnimationScript;
    public GameObject m_immobile;
    public GameObject m_walkable;
    public GameObject m_drivable;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    */

    IEnumerator LoadLeveCoroutine(int levelIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        m_elevatorAnimationScript.CloseDoor();
        SwitchPlayer(levelIndex);
        StartCoroutine(LoadLeveCoroutine(1));
        m_elevatorAnimationScript.OpenDoor();

    }

    private void SwitchPlayer(int levelIndex)
    {
        if (levelIndex == 0)
        {
            m_immobile.SetActive(false);
            m_drivable.SetActive(false);
            m_walkable.SetActive(true);
        }
        else if (levelIndex == 1)
        {
            //m_immobile.SetActive(false);
            //m_walkable.SetActive(false);
            //m_drivable.SetActive(true);
			//Désolé Elfo ça marchait pas en fait
        }
        else
        {
            Debug.Log("Scene inconnue");
        }
    }
}
