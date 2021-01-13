using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testmov : MonoBehaviour
{
    bool CanJump = false;
    int counter = 0;
    bool startCounter = false;
    float thrust = 700.0f;
    //rb2d = GetComponent<Rigidbody2D>();

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.Space) && CanJump == true)
        {
            Debug.Log("Jump");
            CanJump = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrust);
            GetComponent<Rigidbody2D>().gravityScale = 5;
            CanJump = false;
            startCounter = true;

        }*/

        transform.Translate(.1f, 0, 0);

    }
    public void OnCollisionStay2D(Collision2D coll)
    {
        CanJump = true;
        Debug.Log("Stay");
    }
    public void OnCollisionExit2D(Collision2D coll)
    {
        CanJump = false;
        Debug.Log("Exit");
    }
}
