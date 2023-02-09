using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float DestroyTime = 2f;

    private void Start()
    {
        Invoke("Die", DestroyTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
