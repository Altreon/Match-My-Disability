using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool m_isStar;
    private bool m_isQuit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonPressed(string button)
    {
        switch (button)
        {
            case "startButton":
                Debug.Log("sceneName to load: 'LevelOne'");
                SceneManager.LoadScene("LevelOne");
                return;
            default:
                Debug.Log("Button invalid");
                return;
        }
    }
}
