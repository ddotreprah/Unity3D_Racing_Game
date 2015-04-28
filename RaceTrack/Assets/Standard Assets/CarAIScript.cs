using UnityEngine;
using System.Collections;

public class CarAIScript : MonoBehaviour {
    private Transform[] waypoints;
    private int currentWaypoint = 0;

    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public GameObject waypointContainer;
    public float speed = 10.0f;
    public bool isAIActive = false;

    //Help from Dr. Mayfield's waypoints test and https://www.youtube.com/watch?v=VbBY_jezoDI
    // Use this for initialization
    void Start()
    {

        // Get the waypoint transforms.
        if (isAIActive)
        {
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
    }

    void FixedUpdate()
    {
        if (isAIActive)
        {
            Vector3 movement = NavigateTowardWaypoint();

            float rotSpeed = Mathf.Deg2Rad * 360;
            Vector3 nextRot = waypoints[currentWaypoint].position - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, nextRot, Time.deltaTime * rotSpeed, 0.0f));


            GetComponent<Rigidbody>().velocity = movement.normalized * speed * 100 * Time.deltaTime;
        }
    }

    Vector3 NavigateTowardWaypoint()
    {
        Vector3 relativeWaypointPosition =
            waypoints[currentWaypoint].position - transform.position;

        if (relativeWaypointPosition.magnitude < 1)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            print("Current waypoint: " + currentWaypoint);
        }

        return relativeWaypointPosition;

    }
}