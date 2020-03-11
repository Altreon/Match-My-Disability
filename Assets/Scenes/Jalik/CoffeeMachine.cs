using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    private bool cupIsPresent = false;

    [SerializeField] private GameObject particles;
    
    public void SetCupIsPresent()
    {
        cupIsPresent = true;
    }

    public void ButtonPressed()
    {
        if (cupIsPresent)
        {
            //Play sound coffee
            particles.SetActive(true);
            ObjectifManager.Instance.setObjectif("coffee");
        }
        else
        {
            //Play sound error
        }
    }
}
