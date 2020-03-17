using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossLevel1AI : MonoBehaviour
{
    //This script controls the first boss's AI.

    public GameObject enemy;
    public GameObject enemySpearPrefab;
    public Transform spearSpawn;
    public Transform patrolPoint1Follow;
    public Transform patrolPoint2Follow;
    public Transform patrolPoint3Follow;
    public Transform playerFollow;
    public bool movingToPoint1 = false;
    public bool movingToPoint2 = false;
    public bool movingToPoint3 = false;
    public bool reachedPoint1 = false;
    public bool reachedPoint2 = false;
    public bool seePlayer = false;
    public float moveSpeed;
    public float fireRate = 1;
    private float timeLastFired;


    // Use this for initialization
    void Start()
    {
        movingToPoint1 = true;
        playerFollow = GameObject.FindWithTag("Player").transform;
        
    }


    // Update is called once per frame
    void Update()
    {

        //The boss has three booleans which are activated under specific conditions. The boss moves between two points, patrolling back and forth between point one and two.
        //When the boss gets to point one, the boolean movingToPoint1 is deactivated and a new one, movingToPoint2 is activated which moves the boss to the second point.
        //The boss then moves back to the first point and this goes until the player gets close enough that the boss can see him. At this point the boss moves to point three
        //and begins firing spears at the player. The boss rotates toward the player and hurls spears forward in the direction of the player.

        if (movingToPoint1)
        {
            moveSpeed = 50.0f;
            transform.position = Vector3.MoveTowards(transform.position,
            patrolPoint1Follow.transform.position, Time.deltaTime * moveSpeed);
            Vector3 rotateTowardPatrolPoint1 = new Vector3(patrolPoint1Follow.transform.position.x,
            transform.position.y, patrolPoint1Follow.transform.position.z);
            transform.LookAt(rotateTowardPatrolPoint1);
        }
        if (movingToPoint2)
        {
            moveSpeed = 50.0f;
            transform.position = Vector3.MoveTowards(transform.position,
            patrolPoint2Follow.transform.position, Time.deltaTime * moveSpeed);
            Vector3 rotateTowardPatrolPoint2 = new Vector3(patrolPoint2Follow.transform.position.x,
            transform.position.y, patrolPoint2Follow.transform.position.z);
            transform.LookAt(rotateTowardPatrolPoint2);
        }
        if (movingToPoint3)
        {
            moveSpeed = 100.0f;
            transform.position = Vector3.MoveTowards(transform.position,
            patrolPoint3Follow.transform.position, Time.deltaTime * moveSpeed);
            Vector3 rotateTowardPlayer = new Vector3(playerFollow.transform.position.x,
            transform.position.y, playerFollow.transform.position.z);
            transform.LookAt(rotateTowardPlayer);
        }

        if (seePlayer)
        {
            movingToPoint3 = true;
            movingToPoint1 = false;
            movingToPoint2 = false;
        }

        if (enemy.transform.position.x == patrolPoint1Follow.transform.position.x)
        {
            reachedPoint1 = true;
            reachedPoint2 = false;
            movingToPoint1 = false;
            movingToPoint2 = true;
        }
        else if (enemy.transform.position.x == patrolPoint2Follow.transform.position.x)
        {
            reachedPoint1 = false;
            reachedPoint2 = true;
            movingToPoint1 = true;
            movingToPoint2 = false;
        }

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
            throwEnemySpear();
        }
    }

    void throwEnemySpear()
    {

        GameObject enemySpear = Instantiate(enemySpearPrefab);
        enemySpear.transform.position = spearSpawn.transform.position;
        enemySpear.transform.rotation = spearSpawn.transform.rotation;
        
        enemySpear.GetComponent<Rigidbody>().velocity = enemySpear.transform.forward * 150;

        Destroy(enemySpear, 5.0f);

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.throwSpear);
    }
}
