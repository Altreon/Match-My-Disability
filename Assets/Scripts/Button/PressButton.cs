using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    public UnityEvent clickEvent;
    
    public void click () {
		Debug.Log("button click");
        clickEvent.Invoke();
    }
}
