using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Keep track of total coins in scene.
    public static int CoinCount = 0;
    
    void Awake()
    {
        // Object created, increment coin count.
        ++CoinCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player walks into the coin, destroy the coin.
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Decrement coin count.
        --CoinCount;
        
        // Check remaining counts.
        if (CoinCount <= 0)
        {
            // Game is won. Collect all coins. Destroy timer and launch fireworks.
            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);

            GameObject[] FireWorksSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach (GameObject gameObject in FireWorksSystems)
            {
                gameObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
