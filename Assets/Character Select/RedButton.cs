using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RedButton : MonoBehaviour {
    public void SaveRed()
    {
        StreamWriter SW = new StreamWriter(Application.persistentDataPath + "CharacterSave.txt");
        SW.WriteLine("Red");
        SW.Flush();
        SW.Close();
    }
}
