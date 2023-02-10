using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Transform thisTransform = null;
    public float MaxSpeed = 10f;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        thisTransform.position += thisTransform.forward * MaxSpeed * Time.deltaTime;
    }
}
