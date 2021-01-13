using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    bool Done = false;
    private void Awake()
    {
    }
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<Death>().LComplete == true)
        {
            Debug.Log("FINSHED");
            //for(int i=0; i <1)
        transform.GetChild(0).gameObject.SetActive(true);
        Done = true;
        }
    }
}
