using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    [SerializeField] List<Button> levelsButton;
    [SerializeField] List<Image> levelsImage;

    // Start is called before the first frame update
    void Awake()
    {
        //Get level information
        //If maxlevel bigger then total levels, set maxLevel
        if (PlayerPrefs.GetInt("MaxLevel") <= 0) PlayerPrefs.SetInt("MaxLevel", 1);
        if (PlayerPrefs.GetInt("MaxLevel") > levelsButton.Count) PlayerPrefs.SetInt("MaxLevel", levelsButton.Count);
        SetUnlockedLevel();
    }

    //Unlock buttons by MaxLevel
    void SetUnlockedLevel()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("MaxLevel"); i++)
        {
            levelsButton[i].enabled = true;
            levelsImage[i].color = new Color(255, 255, 255, 1);
        }
    }
    //Open level which clicked button
    public void OpenLevel()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(levelName);
    }
}
