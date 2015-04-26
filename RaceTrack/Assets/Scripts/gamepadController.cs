using UnityEngine;
using System.Collections;

public class gamepadController : MonoBehaviour
{

    // Use this for initialization
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public float maxTorque = 30.0f;
    public float maxSpeed = 20.0f;
    public float speed = 10.0f;            // The speed that the player will move at.
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    public bool isActive;

    void start()
    {
        rigidbody.centerOfMass.y = -2.0f;
    }
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (isActive ==  true)
        {
            float h = Input.GetAxisRaw("RightH");  // Input.GetAxisRaw("Horizontal");
            float v = -Input.GetAxisRaw("RightV");  // Input.GetAxisRaw ("Vertical");

            // Move the player forward or backward.
            Walk(System.Math.Min(0, v));

            // Turn the player to face the mouse cursor.
            Turn(h);
        }
        
    }

    void Walk(float v)
    {
        // Set the movement vector based on the axis input.
        wheelRR.motorTorque = -maxTorque * v;
        wheelRL.motorTorque = -maxTorque * v;

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }

    void Turn(float h)
    {
        wheelFL.steerAngle = 10 * h;
        wheelFR.steerAngle = 10 * h;
    }
}
