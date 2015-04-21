using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	// Use this for initialization
	Font pauseMenuFont;
	private bool pauseEnabled = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			
			pauseEnabled = true;
			AudioListener.volume = 0;
			Time.timeScale = 0;
			
			
		}
		
	}
	void OnGUI()
	{
		
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		if (pauseEnabled == true)
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "Game Paused");
			
			if (GUI.Button (new Rect(Screen.width / 2 - 100, Screen.height / 2 , 250, 50), "Resume"))
			{
				pauseEnabled = false;
				AudioListener.volume = 1;
				Time.timeScale = 1;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 50), "Quit Game"))
			{
				Application.Quit();
			}
		}
	}
}
