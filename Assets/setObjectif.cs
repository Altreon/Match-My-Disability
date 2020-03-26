using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum OBJECTIF
{
    COFFEE,
    NOTEPAD
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
        }
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
    }
}
