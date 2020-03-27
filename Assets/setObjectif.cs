using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum OBJECTIF
{
    COFFEE,
    NOTEPAD,
    PHONE,
    COMPUTER,
    WORK
};
public class setObjectif : MonoBehaviour
{
    [SerializeField] private OBJECTIF objectifToSet;
    [SerializeField] private int requiredStep;
    [SerializeField] private bool setOnce;
    private ObjectifManager instanceManager = null;

    private bool hasBeenSet = false;
    // Start is called before the first frame update
    void Start()
    {
        instanceManager = ObjectifManager.Instance;
    }

    public void Set()
    {
        
        if (instanceManager == null)
        {
            Debug.LogError("C'est bizarre y'a pas l'objectif manager qui est set");
            instanceManager = ObjectifManager.Instance;
            if(instanceManager == null)
                Debug.LogError("Ok là c'est pas normal");
        }
        Debug.Log("set ! " + objectifToSet + " ; " + requiredStep + " ; " + setOnce + " ; " + hasBeenSet + " ; " +
                  instanceManager.StepCoffee);
        switch (objectifToSet)
        {
            case OBJECTIF.COFFEE:
                test("coffee", instanceManager.StepCoffee);
                break;
            case OBJECTIF.NOTEPAD:
                test("note", instanceManager.StepNote);
                break;
            case OBJECTIF.PHONE:
                test("phone", instanceManager.StepPhone);
                break;
            case OBJECTIF.COMPUTER:
                test("computer", 0);
                break;
            default:
                test("work", 0);
                break;

        }
        /*
        if (objectifToSet == OBJECTIF.COFFEE)
        {
            
            if ((!setOnce || !hasBeenSet) && instanceManager.StepCoffee >= requiredStep)
            {
                instanceManager.setObjectif("coffee");
                hasBeenSet = true;
            }
        }
        else
        {
            if ((!setOnce || !hasBeenSet) && instanceManager.StepNote >= requiredStep)
            {
                instanceManager.setObjectif("note");
                hasBeenSet = true;
            }
        }
        */
    }

    private void test(string name, int nb)
    {
        if ((!setOnce || !hasBeenSet) && nb >= requiredStep)
        {
            instanceManager.setObjectif(name);
            hasBeenSet = true;
        }
    }
}
