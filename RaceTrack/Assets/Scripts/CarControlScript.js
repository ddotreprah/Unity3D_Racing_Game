#pragma strict
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var maxTorque : float = 30;
var isActive  = true;
 
 
function Start () {

    rigidbody.centerOfMass.y = -4.0f;
    

}

function FixedUpdate () {

if (isActive ==  true)
	{
	    wheelRR.motorTorque = -maxTorque * Input.GetAxis("Vertical");
	    wheelRL.motorTorque = -maxTorque * Input.GetAxis("Vertical");
	    wheelFL.steerAngle = 25 * Input.GetAxis("Horizontal");
	    wheelFR.steerAngle = 25 * Input.GetAxis("Horizontal");
	 }   
   
}