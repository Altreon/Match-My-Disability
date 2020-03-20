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

    public PlayerActivator activator;
    
    // Start is called before the first frame update
    void Start()
    {
        if(activator == null)
            Debug.LogError("activator est null ! Initailise le dans l'éditeur stp");
    }
    

    IEnumerator LoadLeveCoroutine(int levelIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        m_elevatorAnimationScript.OpenDoor();
    }

    public void LoadLevel(int levelIndex)
    {
        m_elevatorAnimationScript.CloseDoor();
        SwitchPlayer(levelIndex);
        StartCoroutine(LoadLeveCoroutine(1));
        //Je l'ai déplacé pour qu'on ouvre la porte à la fin du chargement

    }

    private void SwitchPlayer(int levelIndex)
    {
        activator.switchPlayer(levelIndex);
        /* Désolé ça ne marchait pas d'activer et désactiver les gameobject finalement
         Il faut que tout se fasse dans le même game object et c'est pour ça que j'ai fais un nouveau script
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
        */
    }
}
