using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadSaveText : MonoBehaviour {
    public string LoadText = "none";
    public string SaveText = "none";
    Text text;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = LoadText;
	}
}
