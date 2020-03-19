using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDrivablePlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Drivable");

        if (playerObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
