using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float Damage = 100f;
    public float LifeTime = 2f;

    private void OnEnable()
    {
        CancelInvoke();
        Invoke("Die", LifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        var h = other.GetComponent<Health>();
        if (h != null)
        {
            h.HealthPoints -= Damage;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
