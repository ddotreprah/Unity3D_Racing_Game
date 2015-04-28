using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
	Font text;
	public bool toogle;
	public CarControlScript vector;
	public CarAIScript VectorAI;
	public CarControlScript broken;
	public CarAIScript BrokenAI;
	public CarControlScript lucky;
	public CarAIScript LuckyAI;
	
	// Use this for initialization
	void Awake(){
		vector = GetComponent<CarControlScript>();
		VectorAI = GetComponent<CarAIScript>();
		broken = GetComponent<CarControlScript>();
		BrokenAI = GetComponent<CarAIScript>();
		lucky = GetComponent<CarControlScript>();
		LuckyAI = GetComponent<CarAIScript>();


	}
	void Start () {
		Time.timeScale = 0;
		AudioListener.volume = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnGUI(){
		GUI.skin.box.font = text;
		GUI.skin.button.font = text;
		if (toogle == true) {
			GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300,300), "Finished. Place: " + place.ToString());
			
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250,50), "Lucky"))
			{
					
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250,50), "Broken"))
			{

			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250,50), "Vector"))
			{

			}
		}
	}
}
