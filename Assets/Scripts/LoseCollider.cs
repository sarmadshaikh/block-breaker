using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelToggler levelManager;

	void Start()
	{
		levelManager = GameObject.FindObjectOfType<LevelToggler> ();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		print ("Trigger");
		levelManager.GotoLevel ("Lose");
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		print ("Collision");
	}

}
