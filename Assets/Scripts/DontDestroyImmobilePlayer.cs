using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyImmobilePlayer : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] playerObjs = GameObject.FindGameObjectsWithTag("Immobile");

        if (playerObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
