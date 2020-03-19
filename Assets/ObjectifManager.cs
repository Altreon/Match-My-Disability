using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectifManager : MonoBehaviour
{

    private static ObjectifManager _instance = null;
    [SerializeField] private GameObject targetCamera;
    [SerializeField] private GameObject limit;
    [SerializeField] private float maxDist;
    private Vector3 maxScale;
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

        maxScale = transform.localScale;
        Debug.Log((transform.position - targetCamera.transform.position).magnitude);
    }

    private void Start()
    {
        gameObject.SetActive(false);
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
    
    //CANVS RESCALE
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
}
