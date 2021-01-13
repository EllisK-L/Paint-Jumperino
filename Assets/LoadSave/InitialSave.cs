using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class InitialSave : MonoBehaviour {
    string line = "";
void Awake()
    {
        try
        {
            StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSaves.txt");
            SR.Close();
            return;
        }
        catch
        {
            StreamWriter SW = new StreamWriter(Application.persistentDataPath + "LevelSaves.txt");
            SW.WriteLine("DevLevelincomplete");
            SW.WriteLine("DevLevel2incomplete");
            SW.Flush();
            SW.Close();
            
            StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSaves.txt");
            while(line != null)
            {
                line = SR.ReadLine();
                Debug.Log(line);
            }
            

        }
    }

}
