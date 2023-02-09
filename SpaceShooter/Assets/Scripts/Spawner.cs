using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float MaxRadius = 1f;
    public float Interval = 5f;
    public GameObject ObjToSpawn = null;
    private Transform origin = null;

    private void Awake()
    {
        origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, Interval);
    }

    private void Spawn()
    {
        if (origin == null)
        {
            return;
        }

        var spawnPos = origin.position + Random.onUnitSphere * MaxRadius;
        spawnPos = new Vector3(spawnPos.x, 0f, spawnPos.z);

        Instantiate(ObjToSpawn, spawnPos, Quaternion.identity);
    }
}
