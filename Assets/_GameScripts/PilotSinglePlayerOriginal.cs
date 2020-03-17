using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotSinglePlayerOriginal : MonoBehaviour {
    public GameObject player;
    public GameObject mainCamera;
    public GameObject freeFlightCamera;
    public GameObject controlChanger;
    public GameObject spearPrefab;
    public Transform spearSpawn;
    public bool straightFlightMode;
    public bool stillStraightFlightMode;
    public bool freeFlightMode;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        straightFlightMode = true;
		controlChanger = GameObject.FindWithTag ("ControlChange");
    }

    void OnTriggerExit(Collider changer)
	{
		if (changer.gameObject.name == "ControlChanger") 
		{

			if (straightFlightMode)
			{           
				straightFlightMode = false;
				stillStraightFlightMode = true;
				freeFlightMode = false;
				controlChanger.SetActive (false);
			} 
			else if (stillStraightFlightMode) 
			{
				straightFlightMode = false;
				stillStraightFlightMode = false;
				freeFlightMode = true;
				controlChanger.SetActive (false);
			} 
			else if (freeFlightMode) 
			{
				straightFlightMode = true;
				stillStraightFlightMode = false;
				freeFlightMode = false;
				controlChanger.SetActive (false);
			}
		}
	}

    // Update is called once per frame
    void Update()
    {

            if (straightFlightMode)
        {
            mainCamera.SetActive(true);
            freeFlightCamera.SetActive(false);

            transform.position += transform.forward * Time.deltaTime * 25.0f;

            var moveSideToSide = Input.GetAxis("HorizontalPosition") * Time.deltaTime * 50.0f;
            var moveUpAndDown = Input.GetAxis("VerticalPosition") * Time.deltaTime * 50.0f;
            var moveForwardAndBack = Input.GetAxis("SpeedControl") * Time.deltaTime * 50.0f;


            transform.Translate(moveSideToSide, 0, 0);
            transform.Translate(0, moveUpAndDown, 0);
            transform.Translate(0, 0, moveForwardAndBack);

            Quaternion startRotation = transform.rotation;

            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, -10, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, 10, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(-10, 0, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(10, 0, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
            {
                transform.rotation = Quaternion.identity;
            }
        }

        if (stillStraightFlightMode)
        {
            mainCamera.SetActive(true);
            freeFlightCamera.SetActive(false);            

            var moveSideToSide = Input.GetAxis("HorizontalPosition") * Time.deltaTime * 50.0f;
            var moveUpAndDown = Input.GetAxis("VerticalPosition") * Time.deltaTime * 50.0f;
            var moveForwardAndBack = Input.GetAxis("SpeedControl") * Time.deltaTime * 50.0f;


            transform.Translate(moveSideToSide, 0, 0);
            transform.Translate(0, moveUpAndDown, 0);
            transform.Translate(0, 0, moveForwardAndBack);

            Quaternion startRotation = transform.rotation;

            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, -10, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, 10, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(-10, 0, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(10, 0, 0), Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
            {
                transform.rotation = Quaternion.identity;
            }
        }

            if (freeFlightMode)
        {
            mainCamera.SetActive(false);
            freeFlightCamera.SetActive(true);

            transform.position += transform.forward * Time.deltaTime * 25.0f;

            var moveUpAndDown = Input.GetAxis("VerticalPosition") * Time.deltaTime * 50.0f;
            var rotateSideToSide = Input.GetAxis("HorizontalPosition") * Time.deltaTime * 150.0f;
            var moveForwardAndBack = Input.GetAxis("SpeedControl") * Time.deltaTime * 100.0f;

            transform.Translate(0, moveUpAndDown, 0);
            transform.Rotate(0, rotateSideToSide, 0);
            transform.Translate(0, 0, moveForwardAndBack);

        }

        if (Input.GetKeyDown(KeyCode.V))
        {

            if (straightFlightMode)
            {
                straightFlightMode = false;
                stillStraightFlightMode = true;
                freeFlightMode = false;
                controlChanger.SetActive(false);
            }
            else if (stillStraightFlightMode)
            {
                straightFlightMode = false;
                stillStraightFlightMode = false;
                freeFlightMode = true;
                controlChanger.SetActive(false);
            }
            else if (freeFlightMode)
            {
                straightFlightMode = true;
                stillStraightFlightMode = false;
                freeFlightMode = false;
                controlChanger.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            throwSpear();
                        }

        if (player = null)
        {
            mainCamera.SetActive(true);
        }


                    }               
   

    void throwSpear()
    {

        var spear = (GameObject)Instantiate(
            spearPrefab,
            spearSpawn.position,
            spearSpawn.rotation);

        spear.GetComponent<Rigidbody>().velocity = spear.transform.forward * 100.0f;

        Destroy(spear, 10.0f);
    }

}
