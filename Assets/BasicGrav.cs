using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicGrav : MonoBehaviour
{
    bool CanJump = false;
    public bool jumping = false;
    int counter = 0;
    bool startCounter = false;
    float thrust = 1200.0f;
    string jumpTest = "";
    bool exit = true;
    bool enter = false;
    bool pause = false;
    public bool playerPause = false;
    public int jumpcount = 2;
    bool StopCounter = false;
    float Velocity = 0;
	bool jumped = false;
    public bool springCounter = true;
    float velX = 0;
    float velY = 0;
    float velZ = 0;

    //rb2d = GetComponent<Rigidbody2D>();
    public void PausePlayer()
    {
        if (playerPause == false)
        {
            playerPause = true;
            GetComponent<Rigidbody2D>().simulated = false;
            //GameObject.Find("Canvas/MainMenuBTN").SetActive(false);
        }
        else
        {
            playerPause = false;
            GetComponent<Rigidbody2D>().simulated = true;
            //GameObject.Find("Canvas/MainMenuBTN").SetActive(true);
        }
    }
    public void PauseMove()
    {
        if (pause == true)
        {
            pause = false;
            //GameObject.Find("MainMenu").SetActive(true);
        }
        else
        {
            pause = true;
            //GameObject.Find("MainMenu").SetActive(false);
        }
    }

    void Start()
    {
        Input.simulateMouseWithTouches = true;
        //pause2 = GameObject.Find("Canvas/MainMenu");
        GetComponent<Rigidbody2D>().gravityScale = 10;
    }

    void Update()
    {
        if (StopCounter == false)
        {
            Velocity = GetComponent<Rigidbody2D>().velocity.y;
        }
        else
        {
            //Debug.Log(Velocity);
            if(Velocity < -50)
            {
                GetComponent<Death>().BeforeDeath();
                //transform.position = new Vector3(-29.92f, 2.358f, 0);
            }
            StopCounter = false;
        }

        Debug.Log(GetComponent<Death>().LComplete);

        if (playerPause == false && GetComponent<Death>().LComplete == false && GetComponent<Death>().isDead == false)
        {
            transform.Translate(15*Time.deltaTime, 0, 0);
            velX += 15;
            //GameObject.Find("Canvas/MainMenu").SetActive(false);
        }


        if(GetComponent<Death>().LComplete == true)
        {
            GetComponent<Rigidbody2D>().simulated = false;
        }
        if(GetComponent<Death>().isDead == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (GetComponent<Death>().isDead == false)
        {
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        if (Input.GetButtonDown("Fire1") && CanJump == true && pause == false && GetComponent<Death>().isDead == false)
        {
			jumped = true;
            jumpcount -= 1;
            jumping = true;
            Debug.Log("Jump");
            enter = false;
            //CanJump = false;
            if (jumpcount == 1)
            {
                GameObject.Find("PlayerModel").GetComponent<AnimationScr>().beginjump();
                //GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Rigidbody2D>().AddForce(transform.up * thrust*10);
                //GetComponent<Rigidbody2D>().gravityScale = 10;
            }
            else
            {
                //***********
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                //***********

                //GetComponent<Rigidbody2D>().gravityScale = 1;
                GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
                //GetComponent<Rigidbody2D>().gravityScale = 10;
            }
            CanJump = false;
            startCounter = true;

        }
        
        if (jumping == true)
        {
            jumping = false;
            if(jumpcount > 0)
            {
                CanJump = true;
            }
            else
            {
                jumpcount = 2;
            }
        }
        Debug.Log(Application.persistentDataPath);

        //apply all velocity calculations
        GetComponent<Rigidbody2D>().velocity = new Vector3(velX, velY, velZ);

        //clearing all old values
        //velX = GetComponent<Rigidbody2D>().velocity.x;
        velX = 0;
        velY = GetComponent<Rigidbody2D>().velocity.y;
        velZ = 0;
    }

  

    public void OnCollisionStay2D(Collision2D coll)
    {
        if (enter == true)
        {
            jumpcount = 2;
            CanJump = true;
            Debug.Log("Stay");
        }
    }
    public void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("Exit");
        jumpcount = 1;
        exit = true;
        enter = false;
		if (jumped == false) 
		{
			GameObject.Find ("PlayerModel").GetComponent<AnimationScr> ().falling ();
		}
		jumped = false;
    }
    public void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject.Find("PlayerModel").GetComponent<AnimationScr>().landing();
        StopCounter = true;
        enter = true;
        Debug.Log("Eneter");
        if(Input.GetButton("Fire1"))
        {
            GameObject.Find("PlayerModel").GetComponent<AnimationScr>().beginjump();
            jumpcount -= 1;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
  
    }
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Spring" && springCounter == true)
        {
            Debug.Log("SPRING");
            GameObject.Find("Spring WIP").GetComponent<Spring>().springTrig();
            springCounter = false;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Spring")
        {
            springCounter = true;
        }
    }


}
