#pragma strict
var wheelFL : WheelCollider;
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var maxTorque : float = 50;


function Start () {
    rigidbody.centerOfMass.y = -0.9;

}

function FixedUpdate () {
    wheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
    wheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");
    wheelFL.steerAngle = 10 * Input.GetAxis("Horizontal");
    wheelFR.steerAngle = 10 * Input.GetAxis("Horizontal");
}