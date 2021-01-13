using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CharacterLoad : MonoBehaviour {
    Renderer PlayerModel;
    public Material[] Models;
    private void Start()
    {
        StreamReader SR = new StreamReader(Application.persistentDataPath + "CharacterSave.txt");
        string line = SR.ReadLine();
        PlayerModel = GetComponent<Renderer>();
        if (line == "Knuckles")
        {
            PlayerModel.sharedMaterial = Models[0];
        }
       if (line == "Red")
        {
            PlayerModel.sharedMaterial = Models[1];
        }
        SR.Close();

    }
    
}
