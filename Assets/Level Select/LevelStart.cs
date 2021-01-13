using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    public void StartLevel()
    {
        SceneManager.LoadScene(GetComponent<LevelList>().Levels[GetComponent<LevelList>().selector]);
        Debug.Log(GetComponent<LevelList>().Levels[GetComponent<LevelList>().selector]);
    }
}
