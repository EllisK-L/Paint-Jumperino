using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class Save : MonoBehaviour
{

    public void SaveCurrentLevel(string levelToSave)
    {
        StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSaves.txt");
        string LevelsSaved = SR.ReadToEnd();
        if (LevelsSaved.Contains(SceneManager.GetActiveScene() + "incomplete"))
        {
            LevelsSaved.Replace(SceneManager.GetActiveScene() + "incomplete", SceneManager.GetActiveScene() + "complete");
        }

    }
}
