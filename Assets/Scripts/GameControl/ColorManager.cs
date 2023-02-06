using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    //List of all colors
    List<Color> colors = new List<Color> { Color.red, Color.green, 
        Color.blue, Color.yellow, Color.black, Color.magenta,
        Color.white, Color.cyan, new Color(1, 0.5f, 0, 1), new Color(1, 0, 0.5f, 1)
    };

    List<Color> currentColor = new List<Color>();//List of current level color

    [SerializeField] List<SpriteRenderer> stationSR;
    // Start is called before the first frame update
    void Start()
    {
        ChooseColorRandomly();
        ChangeStationColor();
    }

    //Randomly select colors for the level at the beginning of each level
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
            currentColor.Add(tempColor[index]);
            tempColor.RemoveAt(index);
        }
    }
    //Randomly change the color of stations with the correct colors
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
    //Return the color of the train when the train spawns
    public Color ChangeTrainColor()
    {
        return  currentColor[Random.Range(0, currentColor.Count)];
    }

}
