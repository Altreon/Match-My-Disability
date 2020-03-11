using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    private static ObjectifManager _instance = null;
    public static ObjectifManager Instance
    {
        get { return _instance; }
    }

    [SerializeField] private GameObject objectifCoffee;
    [SerializeField] private GameObject objectifNotepad;

    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Debug.LogError("Can't have 2 OvjectifManager. Destroying second");
            Destroy(gameObject);
        }
    }

    public void setObjectif(string name)
    {
        if(name.Equals("coffee"))
            objectifCoffee.SetActive(true);
        else if(name.Equals("note"))
            objectifNotepad.SetActive(true);
        else
        {
            Debug.LogError("Unkown name : " + name + ", please use 'coffee' or 'note'");
        }
    }

}
