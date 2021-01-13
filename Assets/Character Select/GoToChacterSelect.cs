using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToChacterSelect : MonoBehaviour {
    public void LoadChacterSelect()
        {
        SceneManager.LoadScene("CharacterSelect");
        }
}
