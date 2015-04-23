using UnityEngine;
using System.Collections;

public class CarAIScript : MonoBehaviour {
    private Transform[] waypoints;
    private int currentWaypoint = 0;

    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public GameObject waypointContainer;
    public float speed = 10.0f;
    private float rotationSpeed = 4.0f;
    private float inputSteer = 0.0f;
    private float steeringSharpness = 12.0f;

    // Use this for initialization
    void Start()
    {
        // Get the waypoint transforms.
        Transform[] potentialWaypoints = waypointContainer.GetComponentsInChildren<Transform>();

        waypoints = new Transform[potentialWaypoints.Length - 1];

        print("PlayerScript:  " + potentialWaypoints.Length);

        for (int i = 0, j = 0; i < potentialWaypoints.Length; i++)
        {
            if (potentialWaypoints[i] != waypointContainer.transform)
            {
                // This is not the container; add the waypoint to the array.
                waypoints[j++] = potentialWaypoints[i];
            }
        }

        GetComponent<Rigidbody>().velocity = Vector3.right * speed;
    }

    void FixedUpdate()
    {
        //float SpeedLimit = 100;

        Vector3 movement = NavigateTowardWaypoint();

        GetComponent<Rigidbody>().velocity = movement.normalized * speed * 100 * Time.deltaTime;

        	frontLeftWheel.steerAngle = (steeringSharpness) * inputSteer;
	        frontRightWheel.steerAngle = (steeringSharpness) * inputSteer;
    }

    Vector3 NavigateTowardWaypoint()
    {
        Vector3 relativeWaypointPosition =
            waypoints[currentWaypoint].position - transform.position;

        inputSteer = relativeWaypointPosition.x / relativeWaypointPosition.magnitude;

        if (relativeWaypointPosition.magnitude < 1)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            print("Current waypoint: " + currentWaypoint);
            inputSteer = relativeWaypointPosition.x / relativeWaypointPosition.magnitude;
        }

        return relativeWaypointPosition;

    }
}