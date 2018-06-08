using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//print (paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update () {
		// print (this.transform.position - paddle.transform.position);
		//Lock the ball relative to the paddle
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
		}

		// Launch the ball starting the game
		if (Input.GetMouseButtonDown (0) && !hasStarted) {
			// print ("Clicked");
			hasStarted = true;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (hasStarted)
			this.GetComponent<AudioSource>().Play ();
	}
}
