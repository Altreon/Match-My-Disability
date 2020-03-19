using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyWalkablePlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] immobileObjs = GameObject.FindGameObjectsWithTag("Walkable");

        if (immobileObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
