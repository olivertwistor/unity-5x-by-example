using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Maximum time to complete level (in seconds).
    public float MaxTime = 60f;
    
    // Countdown.
    [SerializeField] private float CountDown = 0;

    private void Start()
    {
        CountDown = MaxTime;
    }

    private void Update()
    {
        // Reduce time.
        CountDown -= Time.deltaTime;
        
        // Restart level if time runs out.
        if (CountDown <= 0)
        {
            // Reset coin count.
            Coin.CoinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
