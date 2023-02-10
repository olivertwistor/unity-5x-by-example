using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int Score;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public static GameController instance = null;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }
    }

    public static void GameOver()
    {
        if (instance.GameOverText != null)
        {
            instance.GameOverText.gameObject.SetActive(true);
        }
    }
}
