using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseAndLowerScript : MonoBehaviour {

	//The code causes the object it is placed on to move up and down.
	//I use this code for some of the boss AI in order to make the boss move randomly in each direction.
	//I also used this code to test out some of the different functionality of Mathf properties. 

	Vector3 startPosition;

	public float riseLowerRange = 10;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float x = startPosition.x;
		float y = riseLowerRange * Mathf.Sin (Time.timeSinceLevelLoad) + startPosition.y;
		float z = startPosition.z;
		transform.position = new Vector3 (x, y, z);
	}
}
//Time.timeSinceLevelLoad
//Mathf.Abs  rise
//Mathf.Ceil slowly rise by increments smallest int >= f
//Mathf.Cos,Sin rise and lower
//Mathf.Exp rise quickly
//Mathf.Floor slowly rise, faster than Ceil by increments  largest int <=f
//Mathf.GammaToLinearSpace rise quickly
//Mathf.InverseLerp Moves away from target? Lerp moves towards target
//Mathf.MoveTowards Moves towards a target
//Mathf.Sqrt slowly rise slower than Exp and GTLS
//Mathf.Tan rise and appear at starting location to rise again