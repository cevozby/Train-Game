using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public void MatchObjects(Color trainColor, Color stationColor)
    {
        if (trainColor == stationColor) ScoreManager.currentScore++;
        else return;
    }
}
