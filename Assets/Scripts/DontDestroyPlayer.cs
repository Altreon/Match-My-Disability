using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Player");

        if (playerObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
