using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    private RectTransform rt;

    private Vector3 initialPos = new Vector3();
    [SerializeField] private float intensity;
    [SerializeField] private float speed;

    private float t = 0f;
    private bool up = true;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        initialPos.x = rt.transform.position.x;
        initialPos.y = rt.transform.position.y;
        initialPos.z = rt.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (up)
        {
            t += Time.deltaTime;
            if (t > 1f)
            {
                t = 1f;
                up = false;
            }
        }
        else
        {
            t -= Time.deltaTime;
            if (t < -1f)
            {
                t = -1f;
                up = true;
            }
        }
        */
        rt.transform.position = new Vector3(initialPos.x, initialPos.y  + (Mathf.Sin(Time.time * speed) * intensity), initialPos.z);
    }
}
