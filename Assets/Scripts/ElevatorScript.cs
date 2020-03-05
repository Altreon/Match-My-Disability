using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorScript : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
