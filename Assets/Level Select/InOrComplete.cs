using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InOrComplete : MonoBehaviour {
    string line = "";
	void Update () {
        Debug.Log(GetComponent<LevelList>().Levels[GetComponent<LevelList>().selector] + "Complete");
        StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSaves.txt");
        line = "";
        while (line != null)
        {
            line = SR.ReadLine();
            if (line != null)
            {
                Debug.Log(line);
                if (line == GetComponent<LevelList>().Levels[GetComponent<LevelList>().selector]+"complete")
                {
                    GameObject inorcomplete = GameObject.Find("InOrCompleteText");
                    inorcomplete.GetComponent<Text>().text = "Complete";
                }
                if (line == GetComponent<LevelList>().Levels[GetComponent<LevelList>().selector] + "incomplete")
                {
                    GameObject inorcomplete = GameObject.Find("InOrCompleteText");
                    inorcomplete.GetComponent<Text>().text = "Incomplete";
                }
            }
        }
	}
}
