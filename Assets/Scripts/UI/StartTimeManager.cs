using UnityEngine;
using TMPro;

public class StartTimeManager : MonoBehaviour
{
    [SerializeField] float timer; //How long does it wait
    [SerializeField] TextMeshProUGUI startTimerText;
    

    // Update is called once per frame
    void Update()
    {
        SetTimer();
    }

    //Waits 3 seconds before the game starts and prints the seconds on the screen
    void SetTimer()
    {
        startTimerText.text = Mathf.FloorToInt(timer).ToString();
        if (timer > 0f) timer -= Time.deltaTime;
        else
        {
            GameController.isPlayable = true;
            gameObject.SetActive(false);
        }
    }
}
