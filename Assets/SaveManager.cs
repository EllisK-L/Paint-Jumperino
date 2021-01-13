using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour {
    public void SaveLevel(string Level)
    {
        StreamWriter mySW = new StreamWriter(Application.persistentDataPath+"LevelSave.txt");
        mySW.WriteLine("Level1");
        Debug.Log("Done");
        Debug.Log(Application.persistentDataPath);
        mySW.Flush();
        mySW.Close();
        GameObject thetext = GameObject.Find("TheText");
        LoadSaveText loadSaveText = thetext.GetComponent<LoadSaveText>();
        loadSaveText.LoadText = "Saved";
    }
    public void LoadLevel()
    {
        try { 
        StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSave.txt");
        string Savefile = SR.ReadToEnd();
        Debug.Log(Savefile);
            GameObject thetext = GameObject.Find("TheText");
            LoadSaveText loadSaveText = thetext.GetComponent<LoadSaveText>();
            loadSaveText.LoadText = "Loaded"+Savefile;
        }
        catch
        {
            GameObject thetext = GameObject.Find("TheText");
            LoadSaveText loadSaveText = thetext.GetComponent<LoadSaveText>();
            loadSaveText.LoadText = "NOFILE";

        }
    }
}
