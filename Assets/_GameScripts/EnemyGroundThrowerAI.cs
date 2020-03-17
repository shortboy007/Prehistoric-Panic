using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundThrowerAI : MonoBehaviour
{
    public GameObject enemySpearPrefab;
    public Transform spearSpawn;
    public Transform playerFollow;
    public bool seePlayer;
    public float fireRate = 1;
    private float timeLastFired;


    void Start()
    {
        playerFollow = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        //Each enemy constantly checks to see how far they are from the player gameobject. If they are within a certain distance, they can see the player and attack.
        //The enemy rotates toward the player everytime they hurl a spear, making them fairly accurate. 
        //The fire rate code was borrowed from a tutorial for a game called Robot Rampage.

        float distToPlayer = Vector3.Distance(transform.position, playerFollow.transform.position);
        //Debug.Log(distToPlayer);

        if (distToPlayer <= 500.0f)
        {
            seePlayer = true;
        }
        else
        {
            seePlayer = false;
        }

        if (seePlayer && Time.time - timeLastFired > fireRate)
        {   
            
            timeLastFired = Time.time;

            Vector3 rotateTowardPlayer = new Vector3(playerFollow.transform.position.x,
            playerFollow.transform.position.y, playerFollow.transform.position.z);
            transform.LookAt(rotateTowardPlayer);
            throwenemySpear();
        }
    }

    void throwenemySpear()
    {

        GameObject enemySpear = Instantiate(enemySpearPrefab);
        enemySpear.transform.position = spearSpawn.transform.position;
        enemySpear.transform.rotation = spearSpawn.transform.rotation;

        enemySpear.GetComponent<Rigidbody>().velocity = enemySpear.transform.forward * 150.0f;

        Destroy(enemySpear, 5.0f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.throwSpear);
    }
    }
