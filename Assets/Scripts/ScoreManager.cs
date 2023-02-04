using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int totalMatch, currentScore, endScore;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] int coef;

    // Start is called before the first frame update
    void Start()
    {
        totalMatch = 0;
        currentScore = 0;
        endScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "CORRECT" + "\t\t" + currentScore.ToString() + " of " + totalMatch.ToString();
    }

    void CalculateScore()
    {
        endScore = currentScore * LevelManager.currentLevel * coef;
    }
}
