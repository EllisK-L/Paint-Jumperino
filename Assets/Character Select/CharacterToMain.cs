using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterToMain : MonoBehaviour {
    public void CharacterToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
