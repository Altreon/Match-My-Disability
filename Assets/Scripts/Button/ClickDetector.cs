using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    PressButton button;

    void Start () {
        button = transform.parent.GetComponent<PressButton>();
    }
    void OnCollisionEnter(Collision collision) {
        if(collision.transform.tag == "Button") {
            
        }
    }
}
