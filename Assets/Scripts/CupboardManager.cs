using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardManager : MonoBehaviour
{
    // Door1
    [SerializeField]
    private float MaxOpen = -6.1f;
    [SerializeField]
    public float Close = -6.468383f;   
    [SerializeField]
    private Transform door1;

    // Door2
    [SerializeField]
    private float MinAngle2 = 90;
    [SerializeField]
    public float MaxAngle2 = 170;
    [SerializeField]
    private Transform door2;
    
    // Door3
    [SerializeField]
    private float MinAngle3 = 10;
    [SerializeField]
    public float MaxAngle3 = 90;
    [SerializeField]
    private Transform door3;

    private void Update() 
    {

        // Door 1
        Vector3 varY = door1.transform.position;
        varY.y = 0.08600003f;
        door1.transform.position = varY;      

        Vector3 varZ = door1.transform.position;
        varZ.z = -4.276421f;
        door1.transform.position = varZ;     

        if(door1.transform.position.x < Close)
        {
            Vector3 var = door1.transform.position;
            var.x = Close;
            door1.transform.position = var;
        }

        if(door1.transform.position.x > MaxOpen)
        {
            Vector3 var = door1.transform.position;
            var.x = MaxOpen;
            door1.transform.position = var;
        }

        door1.transform.eulerAngles = new Vector3(0,90,0);


        //Door 2
        door2.transform.position = new Vector3(-6.235841f,-0.3869242f,-4.76642f);
        var rot2 = door2.transform.eulerAngles;
        rot2.y = Mathf.Clamp(rot2.y, MinAngle2, MaxAngle2);
        door2.transform.eulerAngles = new Vector3(0,rot2.y,0);

        // Door 3
        door3.transform.position = new Vector3(-6.235841f,-0.3869241f,-3.78642f);
        var rot3 = door3.transform.eulerAngles;
        rot3.y = Mathf.Clamp(rot3.y, MinAngle3, MaxAngle3);
        door3.transform.eulerAngles = new Vector3(0,rot3.y,0);
    }
}
