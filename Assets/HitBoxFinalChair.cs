using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxFinalChair : MonoBehaviour
{
    [SerializeField] private setObjectif setter;


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("whaaaaaaa");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("okkkkk");
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("AAAAAAAAAH");
        if (other.gameObject.CompareTag("FinalChair"))
        {
            setter.Set();
        }
    }
}
