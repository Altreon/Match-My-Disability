using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    private static ObjectifManager _instance = null;
    //[SerializeField] private GameObject targetCamera;
    //[SerializeField] private GameObject limit;
    //[SerializeField] private float maxDist;
    //private Vector3 maxScale;
    public static ObjectifManager Instance
    {
        get { return _instance; }
    }

    [SerializeField] private GameObject[] objectifCoffee;
    [SerializeField] private GameObject[] objectifNotepad;
    [SerializeField] private GameObject[] objectifChair;
    [SerializeField] private GameObject[] objectifComputer;
    [SerializeField] private GameObject[] objectifPhone;
    private int nbObjCoffeeDone = 0;
    private int nbObjNotepadDone = 0;
    private int nbObjChairDone = 0;
    private int nbObjComputerDone = 0;
    private int nbObjPhoneDone = 0;
    public int StepCoffee
    {
        get { return nbObjCoffeeDone; }
    }
    public int StepNote
    {
        get { return nbObjNotepadDone; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            return;
        }
        /*
        maxScale = transform.localScale;
        Debug.Log((transform.position - targetCamera.transform.position).magnitude);
        */
        //TODO : ENLEVER LE COMMENTAIRE gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (_instance == this)
            _instance = null;
    }

    private void OnEnable()
    {
        if (_instance == null)
            _instance = this;
    }

    public void setObjectif(string name)
    {
        if(name.Equals("coffee") && nbObjCoffeeDone < objectifCoffee.Length){
            if(objectifCoffee.Length == 1)
                objectifCoffee[nbObjCoffeeDone++].SetActive(true);
            else{
                objectifCoffee[nbObjCoffeeDone++].SetActive(true);
                if (nbObjCoffeeDone == objectifCoffee.Length - 1)
                    objectifCoffee[nbObjCoffeeDone++].SetActive(true);
            }
        }
        else if(name.Equals("note") && nbObjNotepadDone < objectifNotepad.Length){
            if(objectifNotepad.Length == 1)
                objectifNotepad[nbObjNotepadDone++].SetActive(true);
            else
            {
                objectifNotepad[nbObjNotepadDone++].SetActive(true);
                if (nbObjNotepadDone == objectifNotepad.Length - 1)
                    objectifNotepad[nbObjNotepadDone++].SetActive(true);
            }
        }else if(name.Equals("computer") && nbObjComputerDone < objectifComputer.Length){
            if(objectifComputer.Length == 1)
                objectifComputer[nbObjComputerDone++].SetActive(true);
            else
            {
                objectifComputer[nbObjComputerDone++].SetActive(true);
                if (nbObjComputerDone == objectifComputer.Length - 1)
                    objectifComputer[nbObjComputerDone++].SetActive(true);
            }
        }else if(name.Equals("phone") && nbObjPhoneDone < objectifPhone.Length){
            if(objectifPhone.Length == 1)
                objectifPhone[nbObjPhoneDone++].SetActive(true);
            else
            {
                objectifPhone[nbObjPhoneDone++].SetActive(true);
                if (nbObjPhoneDone == objectifPhone.Length - 1)
                    objectifPhone[nbObjPhoneDone++].SetActive(true);
            }
        }else if(name.Equals("work") && nbObjChairDone < objectifChair.Length){
            if(objectifChair.Length == 1)
                objectifChair[nbObjChairDone++].SetActive(true);
            else
            {
                objectifChair[nbObjChairDone++].SetActive(true);
                if (nbObjChairDone == objectifChair.Length - 1)
                    objectifChair[nbObjChairDone++].SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Unkown name : " + name + ", please use 'coffee' or 'note'.\nCoffee : " + nbObjCoffeeDone + " / " + objectifCoffee.Length + "\nNotepad : " + nbObjNotepadDone + " / " + objectifNotepad.Length);
        }
    }
    
    //CANVS RESCALE
    /*
    void Update()
    {
        RaycastHit infos;
        Vector3 direction = targetCamera.transform.position - limit.transform.position;
        bool collide = Physics.Raycast(limit.transform.position, direction, out infos,
            maxDist, LayerMask.GetMask("Default"));
        Debug.DrawRay(limit.transform.position, direction, Color.cyan, 0.1f);
        Debug.Log(collide);
        if (collide)
        {
            Vector3 oldPosition = transform.position - targetCamera.transform.position;
            transform.Translate(direction * infos.distance * 2f, Space.World);
            Vector3 newPosition = transform.position - targetCamera.transform.position;
            float ratio = newPosition.magnitude / oldPosition.magnitude;
            Debug.Log(ratio);
            maxDist *= ratio;
            transform.localScale *= ratio;
        }
    }
    */
}
