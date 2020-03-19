using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCanvas : MonoBehaviour
{
    private GameObject toActivate;

    private void Start()
    {
        toActivate = ObjectifManager.Instance.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OKOKOKOK");
        toActivate.SetActive(true);
    }
}
