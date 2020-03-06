using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosKeeper : MonoBehaviour
{
    public Transform buttonLimit;
    public float supOffset = 0.03f;

    float normalDist;
    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        normalDist = Vector3.Distance(buttonLimit.position, transform.position);
        originalPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distFromLimit = Vector3.Distance(buttonLimit.position, transform.position);
        float distFromOrigin = Vector3.Distance(originalPos, transform.position);

        if(distFromLimit > normalDist + supOffset || distFromOrigin > normalDist){
            transform.position = originalPos;
        }
    }
}
