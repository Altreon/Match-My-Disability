using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform wheelchair;
    [SerializeField] private Transform player;
    [SerializeField] private AudioClip wheel_turn;
    [SerializeField] private AudioClip wheel_start;
    [SerializeField] private AudioClip wheel_end;
    [SerializeField] private AudioClip wheel_continue;
    private Vector2 lastFrame = Vector2.zero;
    private static Vector3 forwardVector = new Vector3(0f, 0f, 1f);
    private static Vector3 backwardVector = new Vector3(0f, 0f, -1f);
    // Start is called before the first frame update
    private AudioSource As;
    
    void Start()
    {
        /*
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if (rb != null)
            rb.constraints = RigidbodyConstraints.FreezeAll;
        */
        As = GetComponent<AudioSource>();
    }

    public void Move(Vector2 axis){
        if (Mathf.Abs(axis.y) > Mathf.Abs(axis.x))
        {
            //Déplacement vertical
            if(axis.y > 0f)
                transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, forwardSpeed * Time.deltaTime);
            else
                transform.position = Vector3.Lerp(transform.position, transform.position - transform.forward, backwardSpeed * Time.deltaTime);
        }
        else
        {
            //Rotation
            if(axis.x > 0f){
                transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(Vector3.up * 90), rotateSpeed * Time.deltaTime);
            }
            else{
                transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * Quaternion.Euler(-Vector3.up * 90), rotateSpeed * Time.deltaTime);
            }
        }
    }

    public void UpdateSound(Vector2 axis, float deadzone){
        if (Mathf.Abs(axis.x) < deadzone && Mathf.Abs(axis.y) < deadzone)
        {
            if (!As.clip.Equals(wheel_end))
            {
                As.Stop();
                As.loop = false;
                As.clip = wheel_end;
                As.Play();
            }
            lastFrame = Vector2.zero;
            return;
        }
        
        if (Mathf.Abs(axis.y) > Mathf.Abs(axis.x))
        {
            //Déplacement vertical
            if (!As.clip.Equals(wheel_start) && Mathf.Abs(axis.y) < 0.4f)
            {
                As.Stop();
                As.loop = false;
                As.clip = wheel_start;
                As.Play();
                //As.Stop();
                //As.PlayOneShot(wheel_start);
            }
            else if(!As.isPlaying || (!As.clip.Equals(wheel_start) && !As.clip.Equals(wheel_continue)))
            {
                As.Stop();
                As.loop = true;
                As.clip = wheel_continue;
                As.Play();
            }
        }
        else
        {
            //Rotation
            if (!As.clip.Equals(wheel_turn))
            {
                As.Stop();
                As.loop = true;
                As.clip = wheel_turn;
                As.Play();
            }
        }

        lastFrame = axis;
    }
}
