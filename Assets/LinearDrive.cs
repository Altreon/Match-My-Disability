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
    bool isGrabb;

    void Start()
    {
        isGrabb = false;
        close = transform.position.x;
        open = close + 0.442f;
        lastPos = transform.position;
        GetComponent<BoxCollider>().enabled = true;
    }

    // Update is called once per frame

    public void Grab()
    {
        isGrabb = true;
    }

    public void Drop()
    {
        isGrabb = false;
        transform.position = door.transform.position + new Vector3(decalage,0.028f,0f);
    }


    void Update()
    {
<<<<<<< HEAD
        if(lastPos != transform.position && isGrabb == true)
=======
        if(!isGrabb){
            return;
        }

        if(lastPos != transform.position)
>>>>>>> 2ae63ccfc1e10972601d293766e42e669a5a6ae8
        {
            var x = door.transform.position;
            x.x = transform.position.x - decalage;
            door.transform.position = x;
            lastPos = transform.position;
        }

        if(transform.position.x < close && isGrabb == true)
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

        if(transform.position.x > open && isGrabb == true)
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
