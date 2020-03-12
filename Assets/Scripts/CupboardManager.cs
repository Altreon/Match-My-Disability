using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardManager : MonoBehaviour
{
    [SerializeField]
    private float MaxOpen;
    [SerializeField]
    public float Close;   

    private void Update() 
    {
 
        if(transform.position.x < Close)
        {
            Vector3 var = transform.position;
            var.x = Close;
            transform.position = var;
        }

        if(transform.position.x > MaxOpen)
        {
            Vector3 var = transform.position;
            var.x = MaxOpen;
            transform.position = var;
        }
    }
}
