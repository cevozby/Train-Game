using System.Collections;
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
        if (PlayerPrefs.GetInt("MaxLevel") <= 0) PlayerPrefs.SetInt("MaxLevel", 1);
        if (PlayerPrefs.GetInt("MaxLevel") > levelsButton.Count) PlayerPrefs.SetInt("MaxLevel", levelsButton.Count);
        SetUnlockedLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetUnlockedLevel()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("MaxLevel"); i++)
        {
            levelsButton[i].enabled = true;
            levelsImage[i].color = new Color(255, 255, 255, 1);
        }
    }

    public void OpenLevel()
    {
        string levelName = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene(levelName);
    }
}
