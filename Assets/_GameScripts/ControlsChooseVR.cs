using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;

public class ControlsChooseVR : MonoBehaviour
{
    public GameObject player;

    public GameObject avatar;

    public GameObject spearSpawn1;

    public GameObject spearSpawn2;

    public GameObject spearSpawnMiddle;

    public GameObject playerLeftHandSpearSpawn;

    public GameObject playerRightHandSpearSpawn;

    public GameObject controlsMenuCanvas;

    public GameObject mainScreenCanvas;

    public GameObject eventSystem;

    public GameObject simpleControlsButton;

    public GameObject dualWieldControlsButton;

    public int count = 0;

    public bool noControlsChosen;

    public bool simpleControls = false;

    public bool dualWieldControls = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");

        avatar = GameObject.FindWithTag("LocalAvatar");

        spearSpawn1 = player.GetComponent<PilotSinglePlayerVR>().spearShootLeft;
        spearSpawn2 = player.GetComponent<PilotSinglePlayerVR>().spearShootRight;

        spearSpawnMiddle = GameObject.FindWithTag("SpearSpawnMiddle");

        playerLeftHandSpearSpawn = GameObject.FindWithTag("SpearSpawnLeft");

        playerRightHandSpearSpawn = GameObject.FindWithTag("SpearSpawnRight");

        controlsMenuCanvas = GameObject.FindWithTag("Menu");

        eventSystem = GameObject.FindWithTag("EventSystem");
        simpleControlsButton = GameObject.FindWithTag("SimpleControlsButton");
        //dualWieldControlsButton = GameObject.FindWithTag("DualWieldControlsButton");

        noControlsChosen = true;

        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(simpleControlsButton);
    }

    void Update()
    {
        //if (Input.GetButtonDown("Oculus_CrossPlatform_Button2") && noControlsChosen == true)
        //{
        //    eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(simpleControlsButton);
        //}

        count++;

        if(count >= 50)
        {
            Time.timeScale = 0;
        }


        if (simpleControls)
        {
            spearSpawn1 = spearSpawnMiddle;
            spearSpawn2 = spearSpawnMiddle;
            spearSpawnMiddle.SetActive(true);
            avatar.SetActive(false);
            playerLeftHandSpearSpawn.SetActive(false);
            playerRightHandSpearSpawn.SetActive(false);

            closeMenu();
        }
        else if (dualWieldControls)
        {
            spearSpawn1 = playerLeftHandSpearSpawn;
            spearSpawn2 = playerRightHandSpearSpawn;
            spearSpawnMiddle.SetActive(false);
            avatar.SetActive(true);
            playerLeftHandSpearSpawn.SetActive(true);
            playerRightHandSpearSpawn.SetActive(true);
            closeMenu();
        }

    }

    public void resetControls()
    {

        simpleControls = false;
        dualWieldControls = false;

    }

    public void SetSimpleControls()
    {
        resetControls();
        simpleControls = true;
    }

    public void SetDualWieldControls()
    {
        resetControls();
        dualWieldControls = true;
    }

    public void closeMenu()
    {
        Time.timeScale = 1;
        controlsMenuCanvas.SetActive(false);
        noControlsChosen = false;
    }
}