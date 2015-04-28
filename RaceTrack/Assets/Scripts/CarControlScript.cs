using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarControlScript : MonoBehaviour {

	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public WheelCollider wheelRL;
	public WheelCollider wheelRR;
	public float maxTorque = 30;
	public bool isActive  = true;
	public float maxSpeed = 20;
	public bool SecondHalf = true;
	public bool FirstHalf = false;
	public bool finished = false;
	public int lapCounter = 0;
	public int place;
	public GameObject Rac1;
	public GameObject Rac2;
	public CarControlScript Racer1;
	public CarControlScript Racer2;
	public Font pauseMenuFont;
	Text lap;
	Text timer;
	public float myTimer =  0;
	//Script from Easy Roads 3d example -- Unity store
	void Awake()
	{
		Racer1 = Rac1.GetComponent<CarControlScript>();
		Racer2 = Rac2.GetComponent<CarControlScript>();
	}
	
	void Start () {
		
		rigidbody.centerOfMass.y = -2.0f;
		
		
	}
	
	void FixedUpdate () {
		
		if (isActive ==  true)
		{
			wheelRR.motorTorque = -maxTorque * Input.GetAxis("Vertical");
			wheelRL.motorTorque = -maxTorque * Input.GetAxis("Vertical");
			wheelFL.steerAngle = 5 * Input.GetAxis("Horizontal");
			wheelFR.steerAngle = 5 * Input.GetAxis("Horizontal");
			lap.text = "Lap: " + lapCounter.ToString() + "/3";
			timer.text = "Time: "  + myTimer.ToString();
			myTimer += Time.deltaTime;
		}   
		
		
		if(rigidbody.velocity.magnitude > maxSpeed)
		{
			rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
		}
		
		
	}
	
	void OnTriggerEnter( Collider collision )
	{
		
		if (collision.gameObject.tag == "FinishLine") {
			if (SecondHalf == true)
			{
				lapCounter++;
				Debug.Log(lapCounter);
				FirstHalf = true;
				if (lapCounter == 4)
				{
					if ((Racer1.lapCounter < 4 && Racer2.lapCounter < 4))
					{
						
						place = 1;
					}
					else if ((Racer1.lapCounter >= 4 && Racer2.lapCounter < 4) || (Racer1.lapCounter < 4 && Racer2.lapCounter >= 4))
					{
						place = 2;
					}
					else 
					{
						place = 3;
					}
					Debug.Log("Place");
					Debug.Log(place);	
					finished = true;
					
					
				}
				SecondHalf =false;
			}
			
		}
		if (collision.gameObject.tag == "HalfWay")
		{
			if (FirstHalf == true)
			{
				SecondHalf = true;
				FirstHalf = false;
			}
		}
	}
	
	void OnGUI()
	{
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		if (isActive && finished)
		{
			GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 200, 350,300), "Finished. Place: " + place.ToString());
			
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 250,50), "Main Menu"))
			{
				Application.LoadLevel("Menu");	
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 250,50), "Restart Level"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 250,50), "Quit"))
			{
				Application.Quit();
			}
			
		}
		
	}
}
