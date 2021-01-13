using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScr : MonoBehaviour {
    public Animator anim;
    public bool clicked = false;

    // Use this for initialization
    void Start () {
        
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.y < 1 && clicked == true)
        {
            anim.Play("QuadMidJump");
            clicked = false;
        }
	}
    public void beginjump()
    {
        //anim.SetTrigger("BeginJumpSprite");
        anim.Play("QuadJumpStart");
        clicked = true;
        //anim.wrapMode = WrapMode.Once;
        
    }
    public void landing()
    {
        anim.Play("QuadEndJump");
    }
    public void stopAllanim()
    {
        //anim.Play("New State");
    }
	public void falling()
	{
		anim.Play("QuadFalling");
	}
}
