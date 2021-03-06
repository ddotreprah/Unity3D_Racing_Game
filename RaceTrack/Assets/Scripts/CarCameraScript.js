﻿#pragma strict
var Vector : Transform;
var Lucky : Transform;
var Broken : Transform;
var car : Transform;
var distance : float = 6.4;
var height : float = 1.4;
var rotationDamping : float = 3.0;
var heightDamping : float = 2.0;
var zoomRatio : float = 0.5;
var defaultFOV : float = 60;
private var rotationVector : Vector3;
var alli : CarControlScript;
var monk : CarControlScript;
var wolf : CarControlScript;

//Script from Easy Roads 3d example Unity store
function Start () {
	alli = Vector.GetComponent(CarControlScript);
	monk = Lucky.GetComponent(CarControlScript);
	wolf = Broken.GetComponent(CarControlScript);
	
}

function Update()
{
	

	if (alli.isActive)
		{
			car = Vector;
		}
	else if(monk.isActive)
		{
			car = Lucky;
			distance = 4.0f;
		}
	else
		{
			car = Broken;
		}

}

function LateUpdate () {
    //keeps camera behind car at a traditional car racing angle
    var wantedAngle = car.eulerAngles.y;
    var wantedHeight = car.position.y + height;
    var myAngle = transform.eulerAngles.y;
    var myHeight = transform.position.y;
    myAngle = Mathf.LerpAngle(myAngle,wantedAngle,rotationDamping * Time.deltaTime);
    myHeight = Mathf.Lerp(myHeight,wantedHeight,heightDamping * Time.deltaTime);
    var currentRotation = Quaternion.Euler(0,myAngle,0);
    transform.position = car.position;
    transform.position -= currentRotation*Vector3.forward*distance;
    transform.position.y = myHeight;
    //transform.position.x = transform.position.x + 5.0f;
    //transform.position.z = transform.position.z + 6.0f;
    transform.LookAt(car);
}

function FixedUpdate () {
    //keeps camera behind car as it starts to go faster
    var acc = car.rigidbody.velocity.magnitude;
    camera.fieldOfView = defaultFOV + acc*zoomRatio*Time.deltaTime;

}