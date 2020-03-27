using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearDrive : MonoBehaviour
{
    // position close sur l'axe x du tiroir
    private float close;

    // position open sur l'axe x du tiroir
    private float open;
    [SerializeField] 

    // Decalage en x entre l'objet grabb et le tiroir
    private float decalage =  0.287f;

    // Dernière position connue du tiroir
    private Vector3 lastPos;    
    [SerializeField]

    // GameObject faisant référence au tiroir
    GameObject door;

    // Boolean pour savoir si le tiroir bouge
    [SerializeField]
    private bool isGrabb;

    // Rigidbody du tiroir
    private Rigidbody rb;

    // Liste des objets se trouvant dans le tiroir 
    [SerializeField]
    public List<GameObject> ElementsInside = new List<GameObject>();

    void Start()
    {
        // Initalisation des différents paramètres

        isGrabb = false;
        rb = door.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        close = transform.position.x;
        open = close + 0.442f;
        lastPos = transform.position;
        GetComponent<BoxCollider>().enabled = true;

        // On desactive la gravité pour éviter que les objets volent dans tous les sens
        for(int i = 0 ; i < ElementsInside.Count ; i++)
        {
            ElementsInside[i].GetComponent<Rigidbody>().useGravity = false;
            ElementsInside[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    // Update is called once per frame

    public void Grab()
    {
        isGrabb = true;
        rb.isKinematic = false;

        for(int i = 0 ; i < ElementsInside.Count ; i++)
        {
            ElementsInside[i].GetComponent<Rigidbody>().useGravity = false;
            ElementsInside[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Drop()
    {
        // L'objet grabb reprend sa place initiale
        transform.position = door.GetComponent<Transform>().transform.position + new Vector3(decalage,0.028f,0f);
        isGrabb = false;
        rb.isKinematic = true;

        for(int i = 0 ; i < ElementsInside.Count ; i++)
        {
            ElementsInside[i].GetComponent<Rigidbody>().isKinematic = false;            
            ElementsInside[i].GetComponent<Rigidbody>().useGravity = true;
        }
    }


    void FixedUpdate()
    {
        // Deplacement du tiroir en fonction du déplacement de grabb
        if(lastPos != transform.position && isGrabb == true)
        {
            rb.MovePosition(transform.position - new Vector3(decalage,0f,0f));

            for(int i = 0 ; i < ElementsInside.Count ; i++)
            {
                ElementsInside[i].GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(decalage,0f,0f));
            }

            lastPos = transform.position;
        }

        // Contraint le tiroir à ne pas aller plus loin que close
        if(transform.position.x < close && isGrabb == true)
        {
            var pos = transform.position;
            pos.x = close;
            transform.position = pos;

            rb.MovePosition(transform.position - new Vector3(decalage,0f,0f));

            for(int i = 0 ; i < ElementsInside.Count ; i++)
            {
                ElementsInside[i].GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(decalage,0f,0f));
            }

            lastPos = transform.position; 
        }

        // Contraint le tiroir à ne pas aller plus loin que open
        if(transform.position.x > open && isGrabb == true)
        {
            var pos = transform.position;
            pos.x = open;
            transform.position = pos;

            rb.MovePosition(transform.position - new Vector3(decalage,0f,0f));

            for(int i = 0 ; i < ElementsInside.Count ; i++)
            {
                ElementsInside[i].GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(decalage,0f,0f));
            }

            lastPos = transform.position; 
        }
    }

    // Si on récupère un objet présent dans le tiroir, alors on l'enlève de la liste
    public void GrabCup(GameObject obj)
    {
        if(ElementsInside.Contains(obj))
        {
            ElementsInside.Remove(obj); 

            GetComponent<MeshRenderer>().enabled = false; 

            obj.GetComponent<Rigidbody>().useGravity = true;  
            obj.GetComponent<Rigidbody>().isKinematic = false;            
        }
    }
}
