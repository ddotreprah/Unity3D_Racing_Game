using UnityEngine;
using System.Collections;

public class CarCheckpoint : MonoBehaviour {

	public bool FirstHalf = false;
	public bool SecondHalf = true;
	public int lapCounter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "FinishLine") {
			if (SecondHalf == true)
			{
				lapCounter++;
				Debug.Log(lapCounter);
				FirstHalf = true;
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

}
