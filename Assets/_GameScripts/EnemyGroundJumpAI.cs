using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundJumpAI : MonoBehaviour 
{
    public Transform playerFollow;

    public int speed = 100;

    public bool seePlayer;

    public bool hitFloor;

    void Start()
    {
        playerFollow = GameObject.FindWithTag("Player").transform;

        hitFloor = false;
    }

    void Update()
    {
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

        if (seePlayer && hitFloor)
        {
            Vector3 rotateTowardPlayer = new Vector3(playerFollow.transform.position.x,
            transform.position.y, playerFollow.transform.position.z);
            transform.LookAt(rotateTowardPlayer);
            JumpAttack();
        }
    }

    void JumpAttack()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        playerFollow.transform.position, Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.gameObject.tag == "Terrain")
        {
            //spawn();
            hitFloor = true;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);
        }
    }

}
