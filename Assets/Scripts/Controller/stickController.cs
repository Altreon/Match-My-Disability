using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickController : MonoBehaviour
{
    static public bool controlledByRight = false;
    static public bool controlledByLeft = false;

    public bool iAmRight = true;

    public void control(bool controlled){
        if(iAmRight){
            controlledByLeft = controlled;
        }else{
            controlledByLeft = controlled;
        }
    }
}
