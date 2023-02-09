using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticlesPrefab = null;
    public bool ShouldDestroyOnDeath = true;
    private Transform thisTransform = null;
    [SerializeField] private float _healthPoints;
    
    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HealthPoints = 0;
        }
    }

    public float HealthPoints
    {
        get => _healthPoints;

        set
        {
            _healthPoints = value;

            if (_healthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if (DeathParticlesPrefab != null)
                {
                    Instantiate(DeathParticlesPrefab, thisTransform.position, thisTransform.rotation);
                }

                if (ShouldDestroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
