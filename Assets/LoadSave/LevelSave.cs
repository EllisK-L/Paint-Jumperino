using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class LevelSave : MonoBehaviour {
    string line = "";

public void SaveCurrentLevel()
    {
            StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSaves.txt");
            StreamWriter SW = new StreamWriter(Application.persistentDataPath + "LevelSaves.txt");
        Debug.Log("Here");
            while (line != null)
        {
            line = SR.ReadLine();
                if (line != null)
            {
                if (line == SceneManager.GetActiveScene() + "incomplete")
                {
                    line = SceneManager.GetActiveScene() + "complete";
                }
                else
                {
                    SW.WriteLine(line);
                }

            }
            SW.Flush();
            SW.Close();
        }





        }

    }

