using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	float mousePos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mousePos = Input.mousePosition.x / Screen.width * 16; // Gets position of mouse on the world in World Blocks. Our World is of 16 blocks in width
		// print (mousePos);
		this.transform.position = new Vector3(Mathf.Clamp(mousePos, 1.5f, 14.5f), this.transform.position.y, 0f);
	}
}
