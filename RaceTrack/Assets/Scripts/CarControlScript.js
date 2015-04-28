#pragma strict
import UnityEngine.UI;
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var maxTorque : float = 30;
var isActive  = true;
var maxSpeed : float = 20;
var SecondHalf = true;
var FirstHalf = false;
var finished = false;
var lapCounter : int = 0;
var place : int;
public var Rac1 : GameObject;
public var Rac2 : GameObject;
public var Racer1 : CarControlScript;
public var Racer2 : CarControlScript;
public var AI1 : CarAIScript;
public var AI2 : CarAIScript;
var pauseMenuFont : Font;
var lap : UI.Text;
var timer : UI.Text;
var myTimer: float =  0;
//Script from Easy Roads 3d example -- Unity store
function Awake()
{
	Racer1 = Rac1.GetComponent(CarControlScript);
	Racer2 = Rac2.GetComponent(CarControlScript);
	AI1 = Rac1.GetComponent(CarAIScript);
	AI2 = Rac2.GetComponent(CarAIScript);
}

function Start () {

    rigidbody.centerOfMass.y = -2.0f;
    

}



function FixedUpdate () {
	if (AI1.isAIActive == true && AI2.isAIActive == true)
	{
		isActive = true;
	}

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

function OnTriggerEnter(collision : Collider)
	{
		
		if (collision.gameObject.tag == "FinishLine") {
			if (SecondHalf == true)
			{
				lapCounter++;
				Debug.Log(lapCounter);
				FirstHalf = true;
				if (lapCounter == 2)
					{
						if ((Racer1.lapCounter < 2 && Racer2.lapCounter < 2))
							{
							
								place = 1;
							}
						else if ((Racer1.lapCounter >= 2 && Racer2.lapCounter < 2) || (Racer1.lapCounter < 2 && Racer2.lapCounter >= 2))
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

function OnGUI()
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