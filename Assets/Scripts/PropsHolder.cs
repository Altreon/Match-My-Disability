using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventBool : UnityEvent<bool>
{
}

public class PropsHolder : MonoBehaviour
{
    public Transform target;
    public float distanceAccept;
    public bool blink = true;
    [Range(0,1)]
    public float blinkFadeIntensity = 0.5f;
    public float blinkFadeTime = 1f; //en secondes

    public UnityEventBool propsPlaced;

    bool accepted = false;
    Renderer rend;
    Color rendColor;
    bool blinkFade = true;
    float blinkTime = 0f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rendColor = rend.material.color;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= distanceAccept){
            if(!accepted){
                setAccepted(true);
            }
        }else{
            if(accepted){
                setAccepted(false);
            }
        }

        if(blink && rend.enabled){
            blinkUpdate();
        }
    }

    void setAccepted(bool accepted) {
        rend.enabled = !accepted;
        propsPlaced.Invoke(accepted);
        this.accepted = accepted;
    }

    void blinkUpdate () {
        float dt = Time.time - blinkTime;
        bool transition = false;

        if (dt > blinkFadeTime){
            dt = blinkFadeTime;
            transition = true;
        }

        float ratio = dt / blinkFadeTime;
        Color newColor = rendColor;

        if(blinkFade){
            newColor.a = blinkFadeIntensity - blinkFadeIntensity * ratio;
        }else{
            newColor.a = blinkFadeIntensity * ratio;
        }

        rend.material.color = newColor;

        if(transition){
            blinkFade = !blinkFade;
            blinkTime = Time.time;
        }
    }
}
