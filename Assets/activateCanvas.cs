using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCanvas : MonoBehaviour
{
    private ObjectifManager[] toActivate;

    private void Start()
    {
        initializeArray();
    }

    private void initializeArray()
    {
        toActivate = Resources.FindObjectsOfTypeAll<ObjectifManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OKOKOKOK");
        if (toActivate.Length == 0)
        {
            initializeArray();
        }
        foreach (ObjectifManager om in toActivate)
        {
            om.gameObject.SetActive(true);
        }
    }
}
