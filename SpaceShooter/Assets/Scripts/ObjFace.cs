using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    public Transform ObjToFollow = null;
    public bool FollowPlayer = false;
    private Transform thisTransform = null;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
        
        // If we're not going to face the player, return early.
        if (!FollowPlayer)
        {
            return;
        }
        
        // Get player's transform.
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            ObjToFollow = playerObj.GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if (ObjToFollow == null)
        {
            return;
        }

        // Find direction to the followed object and rotate toward it.
        var directionToObj = ObjToFollow.position - thisTransform.position;
        if (directionToObj != Vector3.zero)
        {
            thisTransform.localRotation = Quaternion.LookRotation(directionToObj.normalized, Vector3.up);
        }
    }
}
