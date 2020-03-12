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

        //Door 2
        var rot2 = door2.transform.eulerAngles;
        rot2.y = Mathf.Clamp(rot2.y, MinAngle2, MaxAngle2);
        door2.transform.eulerAngles = rot2;

        // Door 3
        var rot3 = door3.transform.eulerAngles;
        rot3.y = Mathf.Clamp(rot3.y, MinAngle3, MaxAngle3);
        door3.transform.eulerAngles = rot3;
    }
}
