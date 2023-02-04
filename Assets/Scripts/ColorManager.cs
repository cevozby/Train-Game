using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    List<Color> colors = new List<Color> { Color.red, Color.green, 
        Color.blue, Color.yellow, Color.grey, Color.magenta };

    List<Color> currentColor = new List<Color>();

    [SerializeField] List<SpriteRenderer> stationSR;
    // Start is called before the first frame update
    void Start()
    {
        ChooseColorRandomly();
        ChangeStationColor();
    }

    void ChooseColorRandomly()
    {
        int colorCount = LevelManager.currentLevel * 2;
        List<Color> tempColor = new List<Color>();
        for (int i = 0; i < colors.Count; i++)
        {
            tempColor.Add(colors[i]);
        }
        for (int i = 0; i < colorCount; i++)
        {
            int index = Random.Range(0, tempColor.Count);
            Debug.Log("Index: " + index + " color: " + tempColor[index]);
            currentColor.Add(tempColor[index]);
            tempColor.RemoveAt(index);
        }
    }

    void ChangeStationColor()
    {
        List<Color> tempColor = new List<Color>();
        for (int i = 0; i < currentColor.Count; i++)
        {
            tempColor.Add(currentColor[i]);
        }
        for (int i = 0; i < currentColor.Count; i++)
        {
            int index = Random.Range(0, tempColor.Count);
            stationSR[i].color = tempColor[index];
            tempColor.RemoveAt(index);
        }
    }

    public Color ChangeTrainColor()
    {
        return  currentColor[Random.Range(0, currentColor.Count)];
    }

}
