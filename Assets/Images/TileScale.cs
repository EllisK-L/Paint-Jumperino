using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 ObjectScale = new Vector3(0,0,0);
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 ObjectScale = transform.lossyScale;
        Debug.Log(ObjectScale);
		
	}
}
