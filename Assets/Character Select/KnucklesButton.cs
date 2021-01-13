using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KnucklesButton : MonoBehaviour {
    public void SaveNuckles()
    {
        StreamWriter SW = new StreamWriter(Application.persistentDataPath + "CharacterSave.txt");
        SW.WriteLine("Knuckles");
        SW.Flush();
        SW.Close();
    }
}
