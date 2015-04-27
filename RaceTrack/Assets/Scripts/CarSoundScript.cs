using UnityEngine;
using System.Collections;

public class CarSoundScript : MonoBehaviour {

    public AudioClip accel;
    public AudioClip impact;
    private AudioSource audio;

	// Use this for initialization
	void Start () 
    {
        //set the gameObjects AudioSource component to "audio"
        audio = gameObject.GetComponent<AudioSource>();
	}

    //function is called when gameObject collides with another object
    void OnCollisionEnter ()
    {
        //plays the collision impact sound
        audio.PlayOneShot(impact);
    }

	// Update is called once per frame
	void Update () 
    {
        //assigns the accelerate sound to a key or button.  Set to "W" for testing
        //Need to assign this to Joystick forward on Xbox controller
        if (Input.GetKeyDown(KeyCode.W))
        {
            audio.PlayOneShot(accel);
        }
    }
}
