using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTextureing : MonoBehaviour {
	public Texture texture;

	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer>();
		rend.material = new Material(Shader.Find("Legacy Shaders/Diffuse"));
		rend.material.mainTexture = texture;
		Vector3 FloorSize = transform.lossyScale;
		Debug.Log (FloorSize);
		//if (FloorSize [0] > 1) 
		//{
			rend.material.mainTextureScale = new Vector2 (FloorSize [0] / 1.8f, 1);
		//} 
		//else 
		//{
		//	rend.material.mainTextureScale = new Vector2 (1, 1);
		//}


		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
