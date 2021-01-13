using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour {
	public Renderer rend;
	public float scrollSpeed = 2f;
    public float verticalScale = 1.1f;
    public bool wallPause = false;
    public GameObject Player;
	void Start () {
		rend = GetComponent<Renderer>();
	}
	void Update () {
        scrollSpeed = .15f;
        if (GameObject.Find("Player").GetComponent<Death>().isDead == false && wallPause == false)
        {
            if (transform.position.y != 23.29f)
            {
                transform.position = new Vector3(transform.position.x, 5.5f, 1);
            }
            if (Player.GetComponent<Rigidbody2D>().velocity.x != .2f)
            {
                //scrollSpeed = .5f;
                scrollSpeed = (Player.GetComponent<Rigidbody2D>().velocity.x / 101);
            }

            float offset = Time.time * scrollSpeed;
            rend.material.mainTextureOffset = new Vector2(offset, 0);
        }
	}
    public void StopWall()
    {
        wallPause = !wallPause;
    }

}
