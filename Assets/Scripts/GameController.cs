using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameController : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] Transform camPos;
    [SerializeField] Transform camFinPos;

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
        isPlayable = true;
        isEnd = false;
        trainCount = 0;
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioList = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioList>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        SetTimeText();
        LevelControl();
    }

    void LevelControl()
    {
        if(!isPlayable && trainCount == ScoreManager.totalMatch)
        {
            isEnd = true;
            gamePanel.SetActive(false);
            
            Vector3 newPos = new Vector3(camFinPos.position.x, camFinPos.position.y, camPos.position.z);
            camPos.position = Vector3.MoveTowards(camPos.position, newPos, speed * Time.deltaTime);
            if (Vector2.Distance(camPos.position, camFinPos.position) <= 0.05f)
            {
                finishPanel.SetActive(true);
                if(!confettiPlay) PlayConfetties();
            }
                
        }
    }

    void Timer()
    {
        if(isPlayable) timer -= Time.deltaTime;
        if (timer <= 0f) isPlayable = false;
    }
    
    void SetTimeText()
    {
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);
        if (min <= 0) min = 0;
        if (sec <= 0) sec = 0;
        timeText.text = "TIME " + min.ToString() + ":" + sec.ToString();
    }

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
