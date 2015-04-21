using UnityEngine;
using System.Collections;

public class VolumeMenu : MonoBehaviour {

	Font pauseMenuFont;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;

			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250, 200), "Game Over");
			
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250, 50), "Restart"))
			{
				Application.LoadLevel("Pool");
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 250, 50), "Quit Game"))
			{
				Application.Quit();
			}
		}

}
