using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{
    private Transform thisTransform = null;
    public Vector2 HorzRange = Vector2.zero;
    public Vector2 VertRange = Vector2.zero;

    private void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        thisTransform.position = new Vector3(
            Mathf.Clamp(thisTransform.position.x, HorzRange.x, HorzRange.y),
            thisTransform.position.y,
            Mathf.Clamp(thisTransform.position.z, VertRange.x, VertRange.y));
    }
}
