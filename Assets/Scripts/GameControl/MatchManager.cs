using UnityEngine;

public class MatchManager : MonoBehaviour
{
    AudioManager audioManager;
    AudioList audioList;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();//Catch AudioManager script
        audioList = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioList>();//Catch AudioList script
    }

    //Match train and station, if correct, increase the score by one, if incorrect, return.
    //Play correct sound based on answer
    public void MatchObjects(Color trainColor, Color stationColor)
    {
        if (trainColor == stationColor)
        {
            audioManager.PlayAudio(audioList.correctAnswer);
            ScoreManager.currentScore++;
        }
        else
        {
            audioManager.PlayAudio(audioList.wrongAnswer);
            return;
        }
    }
}
