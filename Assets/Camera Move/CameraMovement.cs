using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float cameray = 0;

	// Use this for initialization
	public void Start () {
        transform.position = new Vector3(GameObject.Find("Player").transform.position.x+10, 8, -10);
        cameray = 8;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x > -33 && transform.position.x < 29)
        {
            cameray = 8;
        }
        //Debug.Log(GameObject.Find("Player").transform.position);
        //transform.position = new Vector3(GameObject.Find("Player").transform.position.x,cameray,-10);
        Vector3 Posmove = new Vector3(GameObject.Find("Player").transform.position.x+10, cameray, -10);
        transform.position = Vector3.Lerp(transform.position, Posmove , 10 * Time.deltaTime);
        if (GameObject.Find("Player").transform.position.y - transform.position.y > 3)
        {
            cameray += Mathf.Abs(GameObject.Find("Player").transform.position.y - transform.position.y) / 10;
        }
        if (GameObject.Find("Player").transform.position.y - transform.position.y < -3)
        {
            cameray -= Mathf.Abs(GameObject.Find("Player").transform.position.y - transform.position.y)/10;
        }

    }
}
