using UnityEngine;
using System.Collections;

public class CarSoundScript : MonoBehaviour {

    public AudioClip accel;
    public AudioClip impact;
    public AudioClip idle;
    public AudioClip game_finish;
    private AudioSource audio;
    private int lap_counter = 0;

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

    void OnTriggerEnter(Collider coll)
    {
        //Plays the game over sound when the last lap is completed
        if (coll.gameObject.tag == "FinishLine")
        {
            lap_counter++;
            if (lap_counter >= 3)
            {
                audio.PlayOneShot(game_finish);
            }
        }
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
