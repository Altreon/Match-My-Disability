using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControler : MonoBehaviour
{

    //private int m_currentScene;
    public ElevatorAnimationScript m_elevatorAnimationScript;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(LoadLeve(0));
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
        StartCoroutine(LoadLeveCoroutine(levelIndex));
        m_elevatorAnimationScript.OpenDoor();

    }
}
