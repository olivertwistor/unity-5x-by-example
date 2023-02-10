using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisBody = null;
    private Transform thisTransform = null;
    public Transform[] TurretTransforms;

    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float MaxSpeed = 5f;
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;

    private void Awake()
    {
        thisBody = GetComponent<Rigidbody>();
        thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        // Check fire control.
        if (Input.GetButtonDown(FireAxis) && CanFire)
        {
            foreach (var t in TurretTransforms)
            {
                AmmoManager.SpawnAmmo(t.position, t.rotation);
                CanFire = false;
                Invoke(nameof(EnableFire), ReloadDelay);
            }
        }
    }

    private void FixedUpdate()
    {
        var horz = Input.GetAxis(HorzAxis);
        var vert = Input.GetAxis(VertAxis);
        var moveDirection = new Vector3(horz, 0f, vert);
        thisBody.AddForce(moveDirection.normalized * MaxSpeed);
        
        // Clamp the speed.
        var oldVelocityX = thisBody.velocity.x;
        var oldVelocityY = thisBody.velocity.y;
        var oldVelocityZ = thisBody.velocity.z;
        thisBody.velocity = new Vector3(
            Mathf.Clamp(oldVelocityX, -MaxSpeed, MaxSpeed),
            Mathf.Clamp(oldVelocityY, -MaxSpeed, MaxSpeed), 
            Mathf.Clamp(oldVelocityZ, -MaxSpeed, MaxSpeed));
        
        // Look with mouse?
        if (MouseLook)
        {
            // Update the ship's rotation to face the mouse pointer.
            var mousePosWorld =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            mousePosWorld = new Vector3(mousePosWorld.x, 0f, mousePosWorld.z);
            var lookDirection = mousePosWorld - thisTransform.position;
            
            // Perform the actual rotation.
            thisTransform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
        }
    }

    private void EnableFire()
    {
        CanFire = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
