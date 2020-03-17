using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilotSinglePlayerPlains : MonoBehaviour {
    public GameObject player;
    public GameObject mainCamera;
    public GameObject stillFlightCamera;
    public GameObject freeFlightCamera;
    public GameObject firstPersonCamera;
    public GameObject controlChanger;
    public GameObject spearPrefab;
    public Transform spearSpawn;
    public GameObject menu;
    public GameObject enemySpawner;
    public float defaultMoveSpeed = 25.0f;
    public float playerControlMoveSpeed = 50.0f;

    public Animator playerAnims;

    public int count = 0;

    public bool straightFlightMode;
    public bool stillStraightFlightMode;
    public bool freeFlightMode;
    public bool firstPersonFlightMode;
    //public bool menuShowing = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mainCamera = GameObject.FindWithTag("MainCamera");
        stillFlightCamera = GameObject.FindWithTag("StillFlightCamera");
        freeFlightCamera = GameObject.FindWithTag("FreeFlightCamera");
        firstPersonCamera = GameObject.FindWithTag("FirstPersonCamera");
        spearSpawn = GameObject.FindWithTag("PlayerSpearSpawn").transform;
        //spearPrefab = GameObject.FindWithTag("Spear");
		controlChanger = GameObject.FindWithTag ("ControlChange");
        enemySpawner = GameObject.FindWithTag("Spawner");
        //menu = GameObject.FindWithTag("Menu");
        straightFlightMode = true;
}

    void OnTriggerEnter(Collider changer)
	{
		if (changer.gameObject.name == "ControlChanger") 
		{

			if (straightFlightMode || freeFlightMode || firstPersonFlightMode)
			{
             defaultMoveSpeed = 200.0f;
             enemySpawner.GetComponent<EnemySpawner>().enabled = false;
            } 
		}
	}

    void OnTriggerExit(Collider changer)
    {
        if (changer.gameObject.name == "ControlChanger")
        {

            if (straightFlightMode || freeFlightMode || firstPersonFlightMode)
            {
                defaultMoveSpeed = 25.0f;
                straightFlightMode = false;
                stillStraightFlightMode = true;
                freeFlightMode = false;
                controlChanger.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count == 100)
        {
            flapWing();
        }
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {           
            menuShowing = true;
        }
        if (menuShowing)
        {
            menu.GetComponent<Canvas>().enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuShowing)
        {
            menu.GetComponent<Canvas>().enabled = false;
            menuShowing = false;
        }*/

        if (straightFlightMode)
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            stillFlightCamera.GetComponent<Camera>().enabled = false;
            freeFlightCamera.GetComponent<Camera>().enabled = false;
            firstPersonCamera.GetComponent<Camera>().enabled = false;

            transform.position += transform.forward * Time.deltaTime * defaultMoveSpeed;

            var moveSideToSide = Input.GetAxis("HorizontalPosition") * Time.deltaTime * playerControlMoveSpeed;
            var moveUpAndDown = Input.GetAxis("VerticalPosition") * Time.deltaTime * playerControlMoveSpeed;
            var moveForwardAndBack = Input.GetAxis("SpeedControl") * Time.deltaTime * playerControlMoveSpeed;


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
            mainCamera.GetComponent<Camera>().enabled = false;
            stillFlightCamera.GetComponent<Camera>().enabled = true;
            freeFlightCamera.GetComponent<Camera>().enabled = false;
            firstPersonCamera.GetComponent<Camera>().enabled = false;

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
            mainCamera.GetComponent<Camera>().enabled = false;
            stillFlightCamera.GetComponent<Camera>().enabled = false;
            freeFlightCamera.GetComponent<Camera>().enabled = true;
            firstPersonCamera.GetComponent<Camera>().enabled = false;

            transform.position += transform.forward * Time.deltaTime * 25.0f;

            var moveUpAndDown = Input.GetAxis("VerticalPosition") * Time.deltaTime * 50.0f;
            var rotateSideToSide = Input.GetAxis("HorizontalPosition") * Time.deltaTime * 150.0f;
            var moveForwardAndBack = Input.GetAxis("SpeedControl") * Time.deltaTime * 100.0f;

            transform.Translate(0, moveUpAndDown, 0);
            transform.Rotate(0, rotateSideToSide, 0);
            transform.Translate(0, 0, moveForwardAndBack);

        }

            if(firstPersonFlightMode)
        {
            mainCamera.GetComponent<Camera>().enabled = false;
            stillFlightCamera.GetComponent<Camera>().enabled = false;
            freeFlightCamera.GetComponent<Camera>().enabled = false;
            firstPersonCamera.GetComponent<Camera>().enabled = true;

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

        if (Input.GetKeyDown(KeyCode.V))
        {

            if (straightFlightMode)
            {
                straightFlightMode = false;
                stillStraightFlightMode = true;
                freeFlightMode = false;
                firstPersonFlightMode = false;                
            }
            else if (stillStraightFlightMode)
            {
                straightFlightMode = false;
                stillStraightFlightMode = false;
                freeFlightMode = true;
                firstPersonFlightMode = false;
            }
            else if (freeFlightMode)
            {
                straightFlightMode = false;
                stillStraightFlightMode = false;
                freeFlightMode = false;
                firstPersonFlightMode = true;
            }
            else if (firstPersonFlightMode)
            {
                straightFlightMode = true;
                stillStraightFlightMode = false;
                freeFlightMode = false;
                firstPersonFlightMode = false;
            }
        }

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

        Destroy(spear, 10.0f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.throwSpear);
    }

    void flapWing()
    {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.pterodactylWingFlap);
        count = 0;
    }

}
