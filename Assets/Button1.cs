using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour {
public void StartBtn(string StartGame)
    {
        SceneManager.LoadScene(StartGame);
    }
}
