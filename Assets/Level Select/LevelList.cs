using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelList : MonoBehaviour {
    private void Awake()
    {
        displayLevel();
    }
    public int selector = 0;
    public string[] Levels = new string[] { "DevLevel", "DevLevel2" };

    public void displayLevel()
    {
        selector = selector + 1;
        if (selector > 1)
        {
            selector = 0;
        }
        GameObject levelTextButton = GameObject.Find("LevelTextButton");
        levelTextButton.GetComponent<Text>().text = Levels[selector];
        Debug.Log(selector);
    }
    public void levelBack()
    {
        selector = selector - 1;
        if (selector < 0)
        {
            selector = 1;
        }
        GameObject levelTextButton = GameObject.Find("LevelTextButton");
        levelTextButton.GetComponent<Text>().text = Levels[selector];
        Debug.Log(selector);
    }
}
