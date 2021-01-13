using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishUIActive : MonoBehaviour {
    bool isPaused = false;
    public void PauseGame()
    {

        if (isPaused == false)
        {
            Debug.Log("PAUSE");
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
