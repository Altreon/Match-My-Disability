using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    public UnityEvent clickEvent;
    
    void click () {
        clickEvent.Invoke();
    }
}
