#pragma strict
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var maxTorque : float = 30;
var isActive  = true;
var maxSpeed : float = 20;
var SecondHalf = true;
var FirstHalf = false;
var lapCounter : int = 0;
var place : int;
public var Rac1 : GameObject;
public var Rac2 : GameObject;
public var Racer1 : CarControlScript;
public var Racer2 : CarControlScript;
//Script from Easy Roads 3d example Unity store
function Awake()
{
	Racer1 = Rac1.GetComponent(CarControlScript);
	Racer2 = Rac2.GetComponent(CarControlScript);
}

function Start () {

    rigidbody.centerOfMass.y = -2.0f;
    

}

function FixedUpdate () {

if (isActive ==  true)
	{
	    wheelRR.motorTorque = -maxTorque * Input.GetAxis("Vertical");
	    wheelRL.motorTorque = -maxTorque * Input.GetAxis("Vertical");
	    wheelFL.steerAngle = 5 * Input.GetAxis("Horizontal");
	    wheelFR.steerAngle = 5 * Input.GetAxis("Horizontal");
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
				if (lapCounter == 1)
					{
						if ((Racer1.lapCounter < 1 && Racer2.lapCounter < 1))
							{
							
								place = 1;
							}
						else if ((Racer1.lapCounter == 1 && Racer2.lapCounter < 1) || (Racer1.lapCounter < 1 && Racer2.lapCounter == 1))
							{
								place = 2;
							}
						else 
							{
								place = 3;
							}
						Debug.Log("Place");
						Debug.Log(place);	
					
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