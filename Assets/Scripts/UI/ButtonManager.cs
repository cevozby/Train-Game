using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Open last level
    public void PlayButton()
    {
        if (PlayerPrefs.HasKey("MaxLevel")) SceneManager.LoadScene(PlayerPrefs.GetInt("MaxLevel"));
        else SceneManager.LoadScene(1);
    }
    //Open lext level and save it
    public void NextLevelButton()
    {
        int level = SceneManager.GetActiveScene().buildIndex + 1;
        if (level > PlayerPrefs.GetInt("MaxLevel")) PlayerPrefs.SetInt("MaxLevel", level);
        SceneManager.LoadScene(level);
    }
    //Restart level
    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //Pause the game
    public void PauseButton()
    {
        Time.timeScale = 0;
    }
    //Continue the game
    public void ResumeButton()
    {
        Time.timeScale = 1;
    }
    //Open start scene
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    //Exit the game
    public void ExitButton()
    {
        Application.Quit();
    }
}
