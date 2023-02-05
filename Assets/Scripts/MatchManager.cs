using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    AudioManager audioManager;
    AudioList audioList;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioList = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioList>();
    }

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
