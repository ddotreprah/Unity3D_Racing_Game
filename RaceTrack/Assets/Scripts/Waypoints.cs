using UnityEngine;
using System.Collections;

//Code from Dr.Mayfield's waypoint tutorial
public class Waypoints : MonoBehaviour {

    private static GameObject start;

    public GameObject next;
    public bool isStart = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        if(!next)
        {
            print("This waypoint is not connect " + this);
        }

        if(isStart)
        {
            start = gameObject;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

        if (next)
        {
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }

    Vector3 CalculateTargetPosition (Vector3 position)
    {
        if (Vector3.Distance(transform.position, position) < 1.2)
        {
            // We are getting close to the target waypoint;
            // focus attention on next waypoint.
            return next.transform.position;
        }
        else
        {
            // We still are far away from target waypoint.
            return transform.position;
        }
    }
}
