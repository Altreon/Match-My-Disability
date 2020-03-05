using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairController : MonoBehaviour
{
    [SerializeField] private float deadzone;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform wheelchair;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 forwardMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (axis.magnitude < deadzone)
            return;
        if (Mathf.Abs(axis.y) > Mathf.Abs(axis.x))
        {
            //Déplacement vertical
            if(axis.y > 0f)
                transform.Translate(wheelchair.right * -1f * forwardSpeed * Time.deltaTime, Space.Self);
            else
                transform.Translate(wheelchair.right * backwardSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            //Rotation
            if(axis.x > 0f){
                transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
                //player.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
            }
            else{
                transform.Rotate(0f, rotateSpeed * -1f * Time.deltaTime, 0f);
            }
        }
 
    }
}
