using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
	Font text;
	public bool toogle = true;

	public GameObject vector;
	public CarAIScript VectorAI;
	public GameObject broken;
	public CarAIScript BrokenAI;
	public GameObject lucky;
	public CarAIScript LuckyAI;
	
	// Use this for initialization
	void Awake(){
	//	vector = GetComponent<CarControlScript>();
		VectorAI = vector.GetComponent<CarAIScript>();
	//	broken = GetComponent<CarControlScript>();
		BrokenAI = broken.GetComponent<CarAIScript>();
	//	lucky = GetComponent<CarControlScript>();
		LuckyAI = lucky.GetComponent<CarAIScript>();


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
			GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 300,300), "Finished. Place: ");
			
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250,50), "Lucky"))
			{
				BrokenAI.isAIActive = true;
				VectorAI.isAIActive = true;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				toogle = false; 
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250,50), "Broken"))
			{
				LuckyAI.isAIActive = true;
				VectorAI.isAIActive = true;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				toogle = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250,50), "Vector"))
			{
				BrokenAI.isAIActive = true;
				LuckyAI.isAIActive = true;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				toogle = false;
			}
		}
	}
}
