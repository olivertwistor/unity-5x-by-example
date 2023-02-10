using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    public int ScoreValue = 1;

    private void OnDestroy()
    {
        GameController.Score += ScoreValue;
    }
}
