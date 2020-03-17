using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PilotSinglePlayerVR : MonoBehaviour
{
    public GameObject player;
    public GameObject controlChanger;
    public GameObject enemySpawner;
    public GameObject enemyGroundSpawner;

    public GameObject spearPrefab;
    public GameObject spearShootLeft;
    public GameObject spearShootRight;

    public GameObject eventSystem;

    public GameObject levelSelectButton;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        controlChanger = GameObject.FindWithTag("ControlChange");
        enemySpawner = GameObject.FindWithTag("Spawner");
        eventSystem = GameObject.FindWithTag("EventSystem");
        levelSelectButton = GameObject.FindWithTag("LevelSelectButton");
    }

    void OnTriggerEnter(Collider changer)
    {
        //When the player enters this trigger box called ControlChanger, the spawner which was creating the enemies is removed from the scene and
        //a new one is set active if the level has a second spawner.

        if (changer.gameObject.name == "ControlChanger")
        {
                Destroy(enemySpawner);
                if (enemyGroundSpawner != null)
                {
                    enemyGroundSpawner.SetActive(true);
                }
            }
        }

    void OnTriggerExit(Collider changer)
    {
        //The ControlChanger is turned off when the player exits the triggerbox.

        if (changer.gameObject.name == "ControlChanger")
        {
                controlChanger.SetActive(false);            
        }
    }

    void Update()
    {
        //This control scheme allows the player to use the Oculus Touch Controllers to move the player manually. There is no automatic movement in this mode.
        //I commented out the rotation part of this script because it allowed to much freedom for the player. The player who I had test this was able
        //to fly to the side of the level while sitting in one spot and constantly shooting enemies, while collecting infinite health and points.

        var forwardbackward = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical") * Time.deltaTime * 50.0f;
        var leftright = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal") * Time.deltaTime * 50.0f;
        var updown = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") * Time.deltaTime * 50.0f;
        //var rotate = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal") * Time.deltaTime * 50.0f;

        transform.Translate(0, 0, forwardbackward);
        transform.Translate(0, updown, 0);
        transform.Translate(leftright, 0, 0);
        //transform.Rotate(0, rotate, 0);


        //This code allows the player to fire a spear from either the left or right avatar hands, or any other game object that could be suitable for launching projectiles
        //by pressing down on the thumbsticks or the triggers.

        if (Input.GetButtonDown("Oculus_CrossPlatform_PrimaryThumbstick") || Input.GetButtonDown("Oculus_CrossPlatform_PrimaryIndexTrigger"))
        {
            throwSpearLeftHand();
        }

        if (Input.GetButtonDown("Oculus_CrossPlatform_SecondaryThumbstick") || Input.GetButtonDown("Oculus_CrossPlatform_SecondaryIndexTrigger"))
        {
            throwSpearRightHand();
        }

        if (Input.GetButtonDown("Oculus_CrossPlatform_Button4") || Input.GetButtonDown("Oculus_CrossPlatform_Button2"))
        {
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(levelSelectButton);
        }

    }

    void throwSpearLeftHand()
    {

        var spear = (GameObject)Instantiate(
            spearPrefab,
            spearShootLeft.transform.position,
            spearShootLeft.transform.rotation);


        spear.GetComponent<Rigidbody>().velocity = spear.transform.forward * 100;


        Destroy(spear, 10.0f);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.throwSpear);
    }

    void throwSpearRightHand()
    {

        var spear = (GameObject)Instantiate(
            spearPrefab,
            spearShootRight.transform.position,
            spearShootRight.transform.rotation);


        spear.GetComponent<Rigidbody>().velocity = spear.transform.forward * 100;


        Destroy(spear, 10.0f);
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.throwSpear);
    }
}
