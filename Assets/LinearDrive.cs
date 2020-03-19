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
    Transform door;
    void Start()
    {
        close = transform.position.x;
        open = close + 0.442f;
        lastPos = transform.position;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame

    /*
    public void Grab()
    {
        if(lastPos != transform.position)
        {
            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x < close)
        {
            var pos = transform.position;
            pos.x = close;
            transform.position = pos;
            lastPos = transform.position; 

            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x > open)
        {
            var pos = transform.position;
            pos.x = open;
            transform.position = pos;
            lastPos = transform.position; 

            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }
    }

    public void Drop()
    {
        transform.position = door.transform.position + new Vector3(0.275f,0.028f,0f);
    }
    */

    void Update()
    {
        if(lastPos != transform.position)
        {
            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x < close)
        {
            var pos = transform.position;
            pos.x = close;
            transform.position = pos;
            lastPos = transform.position; 

            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x > open)
        {
            var pos = transform.position;
            pos.x = open;
            transform.position = pos;
            lastPos = transform.position; 

            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }
    }
}
