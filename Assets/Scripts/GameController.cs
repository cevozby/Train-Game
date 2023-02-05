using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] TextMeshProUGUI timeText;

    public static bool isPlayable;
    // Start is called before the first frame update
    void Start()
    {
        isPlayable = true;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        SetTimeText();
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

}
