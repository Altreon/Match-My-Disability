using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    [SerializeField] private GameObject pointToFollow;
    private Rigidbody rb;
    private bool isFollowing = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            rb.MovePosition(pointToFollow.transform.position);
        }        
    }

    public void StartFollowing()
    {
        isFollowing = true;
    }

    public void StopFollowing()
    {
        isFollowing = false;
        rb.velocity = Vector3.zero;
    }
}
