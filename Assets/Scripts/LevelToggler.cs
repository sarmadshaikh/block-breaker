using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelToggler : MonoBehaviour {

	private Scene scene;

	public void GotoLevel(string name)
	{
		SceneManager.LoadScene (name);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}

	public void LoadNextLevel()
	{
		scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.buildIndex + 1);
	}

	public int GetLevel()
	{
		scene = SceneManager.GetActiveScene ();
		return scene.buildIndex;
	}

}
