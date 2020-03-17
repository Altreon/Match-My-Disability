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
    
    private static Vector3 forwardVector = new Vector3(0f, 0f, 1f);
    private static Vector3 backwardVector = new Vector3(0f, 0f, -1f);
    // Start is called before the first frame update
    
    
    void Start()
    {
        /*
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;
        */
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
                //transform.Translate(forwardVector * forwardSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, forwardSpeed * Time.deltaTime);
            else
                //transform.Translate(backwardVector *  backwardSpeed * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, backwardSpeed * Time.deltaTime);
        }
        else
        {
            //Rotation
            if(axis.x > 0f){
                //transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
                //player.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(Vector3.up * 90), rotateSpeed * Time.deltaTime);
            }
            else{
                //transform.Rotate(0f, rotateSpeed * -1f * Time.deltaTime, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(-Vector3.up * 90), rotateSpeed * Time.deltaTime);
            }
        }
        
    }
}
