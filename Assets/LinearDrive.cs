using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearDrive : MonoBehaviour
{
    [SerializeField] 
    private float close = -10.2f;
    [SerializeField] 
    private float open = -9.739f;
    private Vector3 lastPos;    
    [SerializeField]
    Transform door;
    void Start()
    {
        transform.position = door.position + new Vector3(0.36f,0.06f,0f);
        lastPos = transform.position;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(lastPos != transform.position)
        {
            var x = door.transform.position;
            x.x = transform.position.x - 0.36f;
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
            x.x = transform.position.x - 0.36f;
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
            x.x = transform.position.x - 0.36f;
            door.transform.position = x;
            lastPos = transform.position;
        }
    }
}
