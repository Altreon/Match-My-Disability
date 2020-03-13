using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosKeeper : MonoBehaviour
{
	public enum Axis {X, Y, Z};
	
    public Transform buttonLimit;
    public Transform downButton;
	public Transform upButton;
    public float supOffset = 0.1f;
	public Transform downLimit;
	public Transform upLimit;
	
	public Axis axisConstraint = Axis.X;
	public bool invert;

    //float normalDist;
    //Vector3 originalPos;
	PressButton button;
    Rigidbody rb;
    bool locked = false;
    // Start is called before the first frame update
    void Start()
    {
        /*normalDist = Vector3.Distance(buttonLimit.position, downButton.position);
        originalPos = transform.position;*/

		button = transform.parent.GetComponent<PressButton>();
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

	void Update() {
		float distance = 0;
		switch (axisConstraint) {
			case Axis.X :
				distance = downButton.position.x - buttonLimit.position.x;
				break;
			case Axis.Y : 
				distance = downButton.position.y - buttonLimit.position.y;
				break;
			case Axis.Z : 
				distance = downButton.position.z - buttonLimit.position.z;
				break;
		}
		
		if(invert) {distance *= -1;}
		if(distance < 0 && !locked) {
			button.click();
			locked = true;
		}else if (distance > supOffset && locked){
			locked = false;
		}
	}
	
	void FixedUpdate () {
		float distanceUp = 0;
		float distanceDown = 0;
		switch (axisConstraint) {
			case Axis.X : 
				distanceUp = upLimit.position.x - upButton.position.x;
				distanceDown = downButton.position.x - downLimit.position.x;
				break;
			case Axis.Y : 
				distanceUp = upLimit.position.y - upButton.position.y;
				distanceDown = downButton.position.y - downLimit.position.y;
				break;
			case Axis.Z : 
				distanceUp = upLimit.position.z - upButton.position.z;
				distanceDown = downButton.position.z - downLimit.position.z;
				break;
				
		}
		
		if(invert) {distanceUp *= -1; distanceDown *= -1;}
		if(distanceUp < 0) {transform.Translate(Vector3.up * distanceUp);}
		if(distanceDown < 0) {transform.Translate(Vector3.up * -distanceDown);}
	}
}
