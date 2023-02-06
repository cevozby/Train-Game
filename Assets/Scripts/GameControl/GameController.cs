using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] GameObject finishPanel, gamePanel;

    [SerializeField] List<ParticleSystem> confetties;

    public static bool isPlayable, isEnd;

    public static int trainCount;

    bool confettiPlay;

    AudioManager audioManager;
    AudioList audioList;
    // Start is called before the first frame update
    void Start()
    {
        isPlayable = false;
        isEnd = false;
        trainCount = 0;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioList = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioList>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayable)
        {
            Timer();
            SetTimeText();
        }
        LevelControl();
    }

    //Check the level finish or not
    void LevelControl()
    {
        if(!isPlayable && trainCount == ScoreManager.totalMatch && trainCount != 0)
        {
            isEnd = true;
            gamePanel.SetActive(false);
            
            if (CameraMovement.isFinishMove)
            {
                finishPanel.SetActive(true);
                if(!confettiPlay) PlayConfetties();
            }
                
        }
    }
    //Set timer
    void Timer()
    {
        if(isPlayable) timer -= Time.deltaTime;
        if (timer <= 0f) isPlayable = false;
    }
    //Set timer text
    void SetTimeText()
    {
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);
        if (min <= 0) min = 0;
        if (sec <= 0) sec = 0;
        timeText.text = "TIME " + min.ToString() + ":" + sec.ToString();
    }
    //If the level finish, play confetties
    void PlayConfetties()
    {
        audioManager.PlayAudio(audioList.win);
        for (int i = 0; i < confetties.Count; i++)
        {
            confetties[i].Play();
        }
        confettiPlay = true;
    }

}
