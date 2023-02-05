using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayButton()
    {
        if (PlayerPrefs.HasKey("MaxLevel")) SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
        else SceneManager.LoadScene(1);
    }

    public void NextLevelButton()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        if (level > PlayerPrefs.GetInt("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", level);
        SceneManager.LoadScene(level);
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
