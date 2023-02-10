using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject AmmoPrefab = null;
    public int PoolSize = 100;
    public Queue<Transform> AmmoQueue = new Queue<Transform>();
    private GameObject[] ammoArray;

    public static AmmoManager instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(GetComponent<AmmoManager>());
            return;
        }

        instance = this;
        ammoArray = new GameObject[PoolSize];

        for (var i = 0; i < PoolSize; i++)
        {
            ammoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            var objTransform = ammoArray[i].GetComponent<Transform>();
            objTransform.parent = GetComponent<Transform>();
            AmmoQueue.Enqueue(objTransform);
            ammoArray[i].SetActive(false);
        }
    }

    public static Transform SpawnAmmo(Vector3 position, Quaternion rotation)
    {
        // Get ammo.
        var spawnedAmmo = AmmoManager.instance.AmmoQueue.Dequeue();

        spawnedAmmo.gameObject.SetActive(true);
        spawnedAmmo.position = position;
        spawnedAmmo.localRotation = rotation;
        
        // Add to queue end and return ammo.
        instance.AmmoQueue.Enqueue(spawnedAmmo);
        return spawnedAmmo;
    }
}
