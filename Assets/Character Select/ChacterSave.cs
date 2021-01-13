using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ChacterSave : MonoBehaviour {
public void SaveCharacter()
    {
        StreamWriter SW = new StreamWriter(Application.persistentDataPath + "CharacterSave.txt");
        SW.WriteLine("Oop");
        SW.Flush();
        SW.Close();
    }
}
