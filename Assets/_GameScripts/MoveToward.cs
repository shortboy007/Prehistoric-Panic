using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour {

    //This script simply makes the object which it is placed on move towards whatever the focus object is. Whichever object has the MoveTarget Tag.
    //In this game, all of the flying enemies move towards an object behind the player and engage the player when close enough.
    //When the object reaches its destination, the object is destroyed in order to save memory for new objects being spawned.

    public Transform targetFollow1;
    /*public Transform targetFollow2;
    public Transform targetFollow3;*/
    public float moveSpeed;

    void Start()
    {
        targetFollow1 = GameObject.FindWithTag("MoveTarget").transform;
        /*targetFollow2 = GameObject.FindWithTag("MoveTarget2").transform;
        targetFollow3 = GameObject.FindWithTag("MoveTarget3").transform;*/
    }

    void Update () {

        moveSpeed = 100.0f;

        ChooseTarget();
    }

    void ChooseTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        targetFollow1.transform.position, Time.deltaTime * moveSpeed);
    }
    void OnTriggerEnter(Collider target)
    {
		if (target.gameObject.tag == "MoveTarget") 
		{
			Destroy (gameObject);
		}
    }
}
