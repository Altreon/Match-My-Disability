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

    [SerializeField]
    private bool isGrabb;
    private Rigidbody rb;

    [SerializeField]
    public List<GameObject> ElementsInside = new List<GameObject>();

    void Start()
    {
        isGrabb = false;
        rb = door.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        close = transform.position.x;
        open = close + 0.442f;
        lastPos = transform.position;
        GetComponent<BoxCollider>().enabled = true;

        for(int i = 0 ; i < ElementsInside.Count ; i++)
        {
            ElementsInside[i].GetComponent<Rigidbody>().useGravity = false;
            ElementsInside[i].GetComponent<Rigidbody>().isKinematic = true;
        }

        //GrabCup(ElementsInside[0]);
        //Grab();
    }

    // Update is called once per frame

    public void Grab()
    {
        isGrabb = true;
        rb.isKinematic = false;

        for(int i = 0 ; i < ElementsInside.Count ; i++)
        {
            ElementsInside[i].GetComponent<Rigidbody>().useGravity = false;
            ElementsInside[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Drop()
    {
        transform.position = door.GetComponent<Transform>().transform.position + new Vector3(decalage,0.028f,0f);
        isGrabb = false;
        rb.isKinematic = true;

        for(int i = 0 ; i < ElementsInside.Count ; i++)
        {
            ElementsInside[i].GetComponent<Rigidbody>().useGravity = true;
            ElementsInside[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }


    void FixedUpdate()
    {
        if(lastPos != transform.position && isGrabb == true)
        {
            rb.MovePosition(transform.position - new Vector3(decalage,0f,0f));

            for(int i = 0 ; i < ElementsInside.Count ; i++)
            {
                ElementsInside[i].GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(decalage,0f,0f));
            }

            lastPos = transform.position;
        }

        if(transform.position.x < close && isGrabb == true)
        {
            var pos = transform.position;
            pos.x = close;
            transform.position = pos;

            rb.MovePosition(transform.position - new Vector3(decalage,0f,0f));

            for(int i = 0 ; i < ElementsInside.Count ; i++)
            {
                ElementsInside[i].GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(decalage,0f,0f));
            }

            lastPos = transform.position; 
        }

        if(transform.position.x > open && isGrabb == true)
        {
            var pos = transform.position;
            pos.x = open;
            transform.position = pos;

            rb.MovePosition(transform.position - new Vector3(decalage,0f,0f));

            for(int i = 0 ; i < ElementsInside.Count ; i++)
            {
                ElementsInside[i].GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(decalage,0f,0f));
            }

            lastPos = transform.position; 
        }
    }

    public void GrabCup(GameObject obj)
    {
        if(ElementsInside.Contains(obj))
        {
            ElementsInside.Remove(obj); 

            GetComponent<MeshRenderer>().enabled = false; 

            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().isKinematic = false;             
        }
    }
}
