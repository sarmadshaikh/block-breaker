using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	public AudioClip crack;
    public static int totalBricks;

    private bool IsBreakable;
	private LevelToggler levelManager;
    private int timesHit;

	// Use this for initialization
	void Start () {
        IsBreakable = (this.tag == "Breakable");
        if (IsBreakable)
            totalBricks++;
        timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelToggler> ();
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
		// Plays audio at the point where the brick was
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (IsBreakable) {
			HandleHits ();
		}
    }

	void HandleHits()
	{
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			Destroy (gameObject);
			totalBricks--;
            if (totalBricks == 0)
                levelManager.LoadNextLevel();
		}
		else {
			LoadSprites ();
		}
	}

	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;

		if (hitSprites[spriteIndex])	// Checks if there is a sprite attached at the given index
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
	}

	// Update is called once per frame
	void Update () {
		
	}

	// TODO Remove this method once we actually win

	void SimulateWin()
	{
		levelManager.LoadNextLevel ();
	}
}
