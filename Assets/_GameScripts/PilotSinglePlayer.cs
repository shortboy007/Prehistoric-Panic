using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilotSinglePlayer : MonoBehaviour {
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
    public GameObject enemyGroundSpawner;
    //public GameObject noBoss;

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
        //menu = GameObject.FindWithTag("Menu");
        enemySpawner = GameObject.FindWithTag("Spawner");
        //enemyGroundSpawner = GameObject.FindWithTag("SpawnerGround");
        //noBoss = GameObject.FindWithTag("NoBoss");
        straightFlightMode = true;
}

    void OnTriggerEnter(Collider changer)
	{
        //When the player enters this trigger box called ControlChanger, they speed up and are moved in range of the boss.
        //The spawner which was creating the enemies is removed from the scene and a new one is set active if the level has a second spawner.

		if (changer.gameObject.name == "ControlChanger") 
		{
                defaultMoveSpeed = 200.0f;
                Destroy(enemySpawner);
                if (enemyGroundSpawner != null)
                {
                    enemyGroundSpawner.SetActive(true);
                }             
		}
	}

    void OnTriggerExit(Collider changer)
    {
        //When the player exits the collider called ControlChanger, the default move speed is set and the player is set to stillStraightFlightMode
        //which allows the player to strafe right or left and change altitude without moving forward. This mode is primarily used for boss battles.

        if (changer.gameObject.name == "ControlChanger")
        {
                //noBoss.GetComponent<EnemySpawner>().enabled = true;
                defaultMoveSpeed = 25.0f;
                straightFlightMode = false;
                stillStraightFlightMode = true;
                freeFlightMode = false;
                firstPersonFlightMode = false;
                controlChanger.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //This code was used to time a flapping sound every 100 milliseconds, but ended up overshadowing other sounds. That's why its commented out.
        //
        //count++;
        //if (count == 100)
        //{
        //    flapWing();
        //}

        //What follows is a string of if statements with booleans that relate to a control method. Each method has its own control scheme although they are mostly the same.

        if (straightFlightMode)
        {
            //In this control scheme, the player moves automatically because their transform.position is in the update function and updating every frame. 
            //The player can strafe and change altitude. The Quaternion.Slerp part of the code allows the player to rotate in a certain direction and then
            //return to the original rotation of the object when the button is released.

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

            //In this control scheme, the player does not move automatically because this control scheme is used for manual control of the character as well as boss battles. 
            //The player can strafe and change altitude.

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

            //In this control scheme, the player moves automatically because their transform.position is in the update function and updating every frame. 
            //The player can strafe and change altitude. The player can also rotate right or left which makes this the ideal control scheme for exploring levels.

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

            //This code allows the player to switch between the different control methods by pressing the V button. Each of these booleans corresponds
            //to an if statement in the update function which allows for certain control schemes when the boolean is active.

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

        //This code calls a method called throwSpear which instantiates a spear object and launches it forward at a predetermined speed.

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

    //This is the flapWing method which was referred to in an earlier part of this code.
    //void flapWing()
    //{
    //    SoundManager.Instance.PlayOneShot(SoundManager.Instance.pterodactylWingFlap);
    //    count = 0;
    //}

}
