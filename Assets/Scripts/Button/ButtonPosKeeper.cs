using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosKeeper : MonoBehaviour
{
	public enum Axis {X, Y, Z};
	
    public Transform buttonLimit;
    public Transform downButton;
	public Transform upButton;
    //public float supOffset = 0.03f;
	public Transform downLimit;
	public Transform upLimit;
	
	public Axis axisConstraint = Axis.X;
	public bool invert;

    //float normalDist;
    //Vector3 originalPos;
    Rigidbody rb;
    bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        /*normalDist = Vector3.Distance(buttonLimit.position, downButton.position);
        originalPos = transform.position;*/

        rb = GetComponent<Rigidbody>();
    }

    /*void Update()
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
			 switch (axisConstraint) {
				case Axis.X : rb.constraints &= ~RigidbodyConstraints.FreezePositionX; break;
				case Axis.Y : rb.constraints &= ~RigidbodyConstraints.FreezePositionY; break;
				case Axis.Z : rb.constraints &= ~RigidbodyConstraints.FreezePositionZ; break;
			 }
         }
    }*/
	
	void FixedUpdate () {
		float distanceUp;
		float distanceDown;
		switch (axisConstraint) {
			case Axis.X : 
				distanceUp = upLimit.position.x - upButton.position.x;
				distanceDown = downButton.position.x - downLimit.position.x;
				if(invert) {distanceUp *= -1; distanceDown *= -1;}
				if(distanceUp < 0) {transform.Translate(Vector3.up * distanceUp);}
				if(distanceDown < 0) {transform.Translate(Vector3.up * -distanceDown);}
				break;
			case Axis.Y : 
				distanceUp = upLimit.position.y - upButton.position.y;
				distanceDown = downButton.position.y - downLimit.position.y;
				if(invert) {distanceUp *= -1; distanceDown *= -1;}
				if(distanceUp < 0) {transform.Translate(Vector3.up * distanceUp);}
				if(distanceDown < 0) {transform.Translate(Vector3.up * -distanceDown);}
				break;
			case Axis.Z : 
				distanceUp = upLimit.position.z - upButton.position.z;
				distanceDown = downButton.position.z - downLimit.position.z;
				if(invert) {distanceUp *= -1; distanceDown *= -1;}
				if(distanceUp < 0) {transform.Translate(Vector3.up * distanceUp);}
				if(distanceDown < 0) {transform.Translate(Vector3.up * -distanceDown);}
				break;
		}
	}
}
