using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearDrive : MonoBehaviour
{
    private float close;
    private float open;
    [SerializeField] 
    private float decalage =  0.287f;
    private Vector3 lastPos;    
    [SerializeField]
    GameObject door;
    bool isGrabb;
    private Rigidbody rb;

    void Start()
    {
        isGrabb = false;
        rb = door.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        close = transform.position.x;
        open = close + 0.442f;
        lastPos = transform.position;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame

    public void Grab()
    {
        isGrabb = true;
        rb.isKinematic = false;
    }

    public void Drop()
    {
        isGrabb = false;
        rb.isKinematic = true;
        transform.position = door.GetComponent<Transform>().transform.position + new Vector3(decalage,0.028f,0f);
    }


    void Update()
    {
        if(lastPos != transform.position && isGrabb == true)
        {
            var x = door.GetComponent<Transform>().transform.position;
            x.x = transform.position.x - decalage;
            door.GetComponent<Transform>().transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x < close && isGrabb == true)
        {
            var pos = transform.position;
            pos.x = close;
            transform.position = pos;
            lastPos = transform.position; 

            var x = door.GetComponent<Transform>().transform.position;
            x.x = transform.position.x - decalage;
            door.GetComponent<Transform>().transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x > open && isGrabb == true)
        {
            var pos = transform.position;
            pos.x = open;
            transform.position = pos;
            lastPos = transform.position; 

            var x = door.GetComponent<Transform>().transform.position;
            x.x = transform.position.x - decalage;
            door.GetComponent<Transform>().transform.position = x;
            lastPos = transform.position;
        }
    }
}
