﻿#pragma strict
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var maxTorque : float = 30;
var isActive  = true;
var maxSpeed : float = 20;

//Script from Easy Roads 3d example Unity store
function Start () {

    rigidbody.centerOfMass.y = -2.0f;
    

}

function FixedUpdate () {

if (isActive ==  true)
	{
	    wheelRR.motorTorque = -maxTorque * Input.GetAxis("Vertical");
	    wheelRL.motorTorque = -maxTorque * Input.GetAxis("Vertical");
	    wheelFL.steerAngle = 10 * Input.GetAxis("Horizontal");
	    wheelFR.steerAngle = 10 * Input.GetAxis("Horizontal");
	 }   
   
if(rigidbody.velocity.magnitude > maxSpeed)
	{
	rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
	}
	
   
}