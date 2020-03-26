using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChairScript : MonoBehaviour
{
    [SerializeField] private GameObject chair;
    

    public void RepositionUnGrab()
    {
        transform.position = chair.transform.position;
        transform.rotation = chair.transform.rotation;
    }
}
