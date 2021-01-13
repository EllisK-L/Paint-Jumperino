using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactWithRoller : MonoBehaviour {
    public GameObject Player;
    Vector3 FOURCE = new Vector3(1111,2111,0);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.GetComponent<Rigidbody2D>().AddForce(FOURCE);
        }
    }
}
