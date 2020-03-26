using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickController : MonoBehaviour
{
    //static public bool controlledByRight = false;
    //static public bool controlledByLeft = false;
    static public bool controlled = false;

    public WheelchairController chairController;
    public Renderer handRenderer;
    public Renderer fakeHandRenderer;
    [SerializeField] private float deadzone = 0.25f;
    [SerializeField] private float rotateStick = 10f;

    bool handCollision = false;

    /*public void Control(bool control){
        controlled = control;

        if(control){
            handRenderer.enabled = false;
            fakeHandRenderer.enabled = true;
        }else{
            handRenderer.enabled = true;
            fakeHandRenderer.enabled = false;
        }
    }*/

    void Update () {
        if(handCollision && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > deadzone){
            if(!controlled){
                controlled = true;

                handRenderer.enabled = false;
                fakeHandRenderer.enabled = true;
            }
        }else{
            if(controlled){
                controlled = false;

                handRenderer.enabled = true;
                fakeHandRenderer.enabled = false;
            }
        }
        
        if(!controlled){
            return;
        }

        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        if (axis.magnitude < deadzone){
            transform.rotation = transform.parent.rotation;
            return;
        }

        if (Mathf.Abs(axis.y) > Mathf.Abs(axis.x))
        {
            //Déplacement vertical
            if(axis.y > 0f){
                transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 0, rotateStick);
            }else{
                transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 0, -rotateStick);
            }
        }
        else
        {
            //Rotation
            if(axis.x > 0f){
                transform.rotation = transform.parent.rotation * Quaternion.Euler(rotateStick, 0, 0);
            }
            else{
                transform.rotation = transform.parent.rotation * Quaternion.Euler(-rotateStick, 0, 0);
            }
        }

        chairController.Move(axis);
    }

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.layer != LayerMask.NameToLayer("Hand")){
            return;
        }

        handCollision = true;
    }

    void OnTriggerExit(Collider collider) {
        if(collider.gameObject.layer != LayerMask.NameToLayer("Hand")){
            return;
        }

        handCollision = false;
    }
}
