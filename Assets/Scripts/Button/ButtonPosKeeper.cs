using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosKeeper : MonoBehaviour
{
    public Transform buttonLimit;
    public Transform downButton;
    public float supOffset = 0.03f;

    float normalDist;
    Vector3 originalPos;
    Rigidbody rb;
    bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        normalDist = Vector3.Distance(buttonLimit.position, downButton.position);
        originalPos = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distFromLimit = Vector3.Distance(buttonLimit.position, downButton.position);
        //float distFromOrigin = Vector3.Distance(buttonLimit.position, transform.position);

        //Debug.Log(distFromLimit + " : " + supOffset);

        if(!locked && (distFromLimit < supOffset || distFromLimit > normalDist + supOffset)){
            //transform.position = originalPos;
            Debug.Log("Freeze");
            rb.constraints = RigidbodyConstraints.FreezeAll;
            locked = true;
        }
    }

    void OnCollisionExit(Collision collision) {
        if(!locked){
            return;
        }

         //if (collision.gameObject.tag == "Hand") {
             Debug.Log("UnFreeze");
             rb.constraints &= ~RigidbodyConstraints.FreezePositionY; 
         //}
     }
}
