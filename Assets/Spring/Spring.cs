using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
    public Animator anim;
    public bool springCounter = true;
	void Start () {
        anim = GetComponent<Animator>();
		
	}
	void Update () {
		
	}
    public void springTrig()
    {
        if (springCounter == true)
        {
            anim.Play("SpringWIP");
            springCounter = false;
        }
    }
}
