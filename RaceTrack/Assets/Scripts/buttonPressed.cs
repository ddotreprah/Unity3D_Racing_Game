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

    }

    public void aboutClicked()
    {

    }

    public void optionsClicked()
    {

    }

    public void exitClicked()
    {
        Application.Quit();

    }
}
