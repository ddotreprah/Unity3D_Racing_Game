using UnityEngine;
using System.Collections;
//
public class pickUpRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    //http://unity3d.com/learn/tutorials/projects/roll-a-ball/collecting-pick-up-objects
	// Update is called once per frame
	void Update () 
    {

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
