using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recuperator : MonoBehaviour
{
    public float heightLimitToReset = -2f;
    public float resetSpeed;
    public float acceptDistance = 0.01f;

    Vector3 originalPos;
    Quaternion originalRot;

    bool reset = false;

    Rigidbody rb;
    Collider col;
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!reset){
            if(transform.position.y <= heightLimitToReset){
                rb.isKinematic = true;
                rb.detectCollisions = false;
                col.enabled = false;

                reset = true;
            }

        }else{
            transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime * resetSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, Time.deltaTime * resetSpeed);

            if(Vector3.Distance(transform.position, originalPos) < acceptDistance){
                transform.position = originalPos;
                transform.rotation = originalRot;

                rb.isKinematic = false;
                rb.detectCollisions = true;
                col.enabled = true;

                reset = false;
            }
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Ground")){
            return;
        }

        rb.isKinematic = true;
        rb.detectCollisions = false;
        col.enabled = false;

        reset = true;
    }
}
