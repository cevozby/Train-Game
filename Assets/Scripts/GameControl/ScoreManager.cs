using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int totalMatch, currentScore, endScore;

    [SerializeField] TextMeshProUGUI correctText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI numberText;

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
        correctText.text = "CORRECT" + "\t\t" + currentScore.ToString() + " of " + totalMatch.ToString();
        EndTexts();
    }
    //Set ending text
    void EndTexts()
    {
        if (GameController.isEnd)
        {
            CalculateScore();
            scoreText.text = "Score:" + "\nMax Score:" + "\nCorrect:" + "\nLevel:";
            numberText.text = endScore.ToString() + "\n" + PlayerPrefs.GetInt("Level" + LevelManager.currentLevel.ToString()) +
                "\n" + currentScore.ToString() + " of " + totalMatch.ToString() + "\n" + LevelManager.currentLevel;
        }
    }
    //Calculate score with coefficients
    void CalculateScore()
    {
        endScore = currentScore * LevelManager.currentLevel * coef;
        if( endScore > PlayerPrefs.GetInt("Level" + LevelManager.currentLevel.ToString())) 
            PlayerPrefs.SetInt("Level" + LevelManager.currentLevel.ToString(), endScore);
    }
}
