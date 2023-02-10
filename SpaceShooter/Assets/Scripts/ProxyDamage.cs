using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float DamagePerSecond = 100f;

    private void OnTriggerStay(Collider other)
    {
        var health = other.GetComponent<Health>();
        if (health == null)
        {
            return;
        }

        health.HealthPoints -= DamagePerSecond * Time.deltaTime;
    }
}
