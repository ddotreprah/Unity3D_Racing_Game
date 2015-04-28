using UnityEngine;
using System.Collections;

public class buttonPressed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startClicked()
    {
        Application.LoadLevel("LoadLevel");
    }

    public void learnMoreClicked()
    {
        Application.LoadLevel("LearnToPlay");
    }

    public void aboutClicked()
    {
        Application.LoadLevel("About");
    }

    public void optionsClicked()
    {

    }

    public void exitClicked()
    {
        Application.Quit();

    }

    public void grassyKnoll()
    {
        Application.LoadLevel("Track_1");
    }

    public void frigidLanes()
    {
        Application.LoadLevel("Track_2");
    }

    public void desertOasis()
    {
        Application.LoadLevel("Track_3");
    }

    public void returnToMain()
    {
        Application.LoadLevel("Menu");
    }
}
