using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFinger : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        //transform.position.y -= 20;
    }
}
