using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PilotNetworking3rdPerson : NetworkBehaviour {
public GameObject spearPrefab;
public Transform spearSpawn;

    // Use this for initialization
    void Start () {
	}

    // Update is called once per frame
    void Update()
    {
		if (!isLocalPlayer)
		{
			return;
		}


        //transform.position += transform.forward * Time.deltaTime * 50.0f; automovement

        //transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal")); rotation

		var rotate = Input.GetAxis("HorizontalPosition") * Time.deltaTime * 150.0f;
		//var moveSideToSide = Input.GetAxis("HorizontalPosition") * Time.deltaTime * 50.0f;
		var moveUpAndDown = Input.GetAxis("VerticalPosition") * Time.deltaTime * 50.0f;
		var moveForwardAndBack = Input.GetAxis("SpeedControl") * Time.deltaTime * 50.0f;


		transform.Rotate(0, rotate, 0); 
		transform.Translate(moveUpAndDown, 0, 0);  
		transform.Translate(0, moveForwardAndBack, 0);
		//transform.Translate(0, 0, moveSideToSide);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            throwSpear();
        }
    }

    void throwSpear()
    {

        var spear = (GameObject)Instantiate(
            spearPrefab,
            spearSpawn.position,
            spearSpawn.rotation);


        spear.GetComponent<Rigidbody>().velocity = spear.transform.forward * 100.0f;

        NetworkServer.Spawn(spear);

        Destroy(spear, 10.0f);
    }
}
