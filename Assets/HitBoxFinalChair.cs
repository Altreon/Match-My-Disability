using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxFinalChair : MonoBehaviour
{
    [SerializeField] private setObjectif setter;
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("FinalChair"))
        {
            setter.Set();
        }
    }
}
