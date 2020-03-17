﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandlerSoldierCaveman2Backup : MonoBehaviour
{

    public GameObject soldier1;
    public GameObject soldier2;
    public GameObject soldier3;
    public GameObject soldier4;
    public GameObject soldier5;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public GameObject army1Base;
    public GameObject army1Base2;
    public GameObject army1Base3;

    public GameObject army2Base;
    public GameObject army2Base2;
    public GameObject army2Base3;

	public float NormalSpeed = 10.0f;

	public float AttackSpeed = 15.0f;

	public float FleeSpeed = 20.0f;

	public bool closeToEnemySoldier = false;

    public bool tooFarFromEnemySoldier = false;

    public bool followingPlayer = false;

	public bool moveToEnemyBase1 =false;
	public bool moveToEnemyBase2 = false;
	public bool moveToEnemyBase3 = false;

	public bool retreatToBase1 = false;
	public bool retreatToBase2 = false;
	public bool retreatToBase3 = false;

	public bool attackEnemy1 = false;
	public bool attackEnemy2 = false;
	public bool attackEnemy3 = false;
	public bool attackEnemy4 = false;
	public bool attackEnemy5 = false;

	public float moveSpeed;

    // Use this for initialization
    void Start()
    {
        //tooFarFromEnemySoldier = true;

        Invoke("chooseTag", 1f);

    }

    void chooseTag()
    {
        var chooseSoldierTag = Random.Range(0, 5);

        if (chooseSoldierTag == 0)
        {
            gameObject.tag = "Army2-Soldier1";
        }

        if (chooseSoldierTag == 1)
        {
            gameObject.tag = "Army2-Soldier2";
        }

        if (chooseSoldierTag == 2)
        {
            gameObject.tag = "Army2-Soldier3";
        }

        if (chooseSoldierTag == 3)
        {
            gameObject.tag = "Army2-Soldier4";
        }

        if (chooseSoldierTag == 4)
        {
            gameObject.tag = "Army2-Soldier5";
        }
    }

	void chooseInitialTarget()
	{
		resetState();

		moveSpeed = NormalSpeed;

		var chooseBaseTarget = Random.Range(0, 2);		

		if (chooseBaseTarget == 0)
		{
			moveToEnemyBase1 = true;
		}
		else if (chooseBaseTarget == 1)
		{
			moveToEnemyBase2 = true;
		}
		if (chooseBaseTarget == 2)
		{
			moveToEnemyBase3 = true;
		}

	}

	// Update is called once per frame
	void Update()
	{
		soldier1 = GameObject.FindWithTag("Army2-Soldier1");
		soldier2 = GameObject.FindWithTag("Army2-Soldier2");
		soldier3 = GameObject.FindWithTag("Army2-Soldier3");
		soldier4 = GameObject.FindWithTag("Army2-Soldier4");
		soldier5 = GameObject.FindWithTag("Army2-Soldier5");

		enemy1 = GameObject.FindWithTag("Army1-Soldier1");
		enemy2 = GameObject.FindWithTag("Army1-Soldier2");
		enemy3 = GameObject.FindWithTag("Army1-Soldier3");
		enemy4 = GameObject.FindWithTag("Army1-Soldier4");
		enemy5 = GameObject.FindWithTag("Army1-Soldier5");

		army1Base = GameObject.FindWithTag("Army1-Base");
		army1Base2 = GameObject.FindWithTag("Army1-Base2");
		army1Base3 = GameObject.FindWithTag("Army1-Base3");

		army2Base = GameObject.FindWithTag("Army2-Base");
		army2Base2 = GameObject.FindWithTag("Army2-Base2");
		army2Base3 = GameObject.FindWithTag("Army2-Base3");

		float distToEnemy1 = Vector3.Distance(transform.position, enemy1.transform.position);
		float distToEnemy2 = Vector3.Distance(transform.position, enemy2.transform.position);
		float distToEnemy3 = Vector3.Distance(transform.position, enemy3.transform.position);
		float distToEnemy4 = Vector3.Distance(transform.position, enemy4.transform.position);
		float distToEnemy5 = Vector3.Distance(transform.position, enemy5.transform.position);

		if (distToEnemy1 <= 500.0f || distToEnemy2 <= 500.0f || distToEnemy3 <= 500.0f || distToEnemy4 <= 500.0f || distToEnemy5 <= 500.0f)
		{
			closeToEnemySoldier = true;
		}

		if (closeToEnemySoldier)
		{
			fight ();
		}
		else
		{
			chooseInitialTarget();
		}

		if(moveToEnemyBase1)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army1Base.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy1Base = new Vector3(army1Base.transform.position.x,
            transform.position.y, army1Base.transform.position.z);
            transform.LookAt(rotateTowardarmy1Base);*/
		}

		if (moveToEnemyBase2)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army1Base2.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy1Base2 = new Vector3(army1Base2.transform.position.x,
            transform.position.y, army1Base2.transform.position.z);
            transform.LookAt(rotateTowardarmy1Base2);*/
		}

		if (moveToEnemyBase3)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army1Base3.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy1Base3 = new Vector3(army1Base3.transform.position.x,
            transform.position.y, army1Base3.transform.position.z);
            transform.LookAt(rotateTowardarmy1Base3);*/
		}

		if (retreatToBase1)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army2Base.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy2Base = new Vector3(army2Base.transform.position.x,
            transform.position.y, army2Base.transform.position.z);
            transform.LookAt(rotateTowardarmy2Base);*/
		}

		if (retreatToBase2)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army2Base2.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy2Base2 = new Vector3(army2Base2.transform.position.x,
            transform.position.y, army2Base2.transform.position.z);
            transform.LookAt(rotateTowardarmy2Base2);*/
		}

		if (retreatToBase3)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army2Base3.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy2Base3 = new Vector3(army2Base3.transform.position.x,
            transform.position.y, army2Base3.transform.position.z);
            transform.LookAt(rotateTowardarmy2Base3);*/
		}

		if (attackEnemy1)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			enemy1.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier1 = new Vector3(enemy1.transform.position.x,
			transform.position.y, enemy1.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier1);
			if (enemy1 = null)
			{
				resetState();
				chooseInitialTarget();
			}
		}

		if (attackEnemy2)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy2.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier2 = new Vector3(enemy2.transform.position.x,
				transform.position.y, enemy2.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier2);
			if (enemy2 = null)
			{
				resetState();
				chooseInitialTarget();
			}
		}

		if (attackEnemy3)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy3.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier3 = new Vector3(enemy3.transform.position.x,
				transform.position.y, enemy3.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier3);
			if (enemy3 = null)
			{
				resetState();
				chooseInitialTarget();
			}
		}

		if (attackEnemy4)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy4.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier4 = new Vector3(enemy4.transform.position.x,
				transform.position.y, enemy4.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier4);
			if (enemy4 = null)
			{
				resetState();
				chooseInitialTarget();
			}
		}

		if (attackEnemy5)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy5.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier5 = new Vector3(enemy5.transform.position.x,
				transform.position.y, enemy5.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier5);
			if (enemy5 = null)
			{
				resetState();
				chooseInitialTarget();
			}
		}


	}

	void fleeCondition ()
	{
		var fightOrFlee = Random.Range(0, 3);

		if (fightOrFlee == 0)
		{
			flee();
		}
	}

	void flee()
	{
		Debug.Log("flee2");		

		resetState();

		moveSpeed = FleeSpeed;

		var chooseBaseRetreatTarget = Random.Range(0, 2);

		if (chooseBaseRetreatTarget == 0)
		{
			retreatToBase1 = true;
		}
		else if (chooseBaseRetreatTarget == 1)
		{
			retreatToBase2 = true;
		}
		if (chooseBaseRetreatTarget == 2)
		{
			retreatToBase3 = true;
		}
	}

	void fight()
	{
		Debug.Log("fight2");

		resetState();

		moveSpeed = AttackSpeed;
	
		var chooseEnemyTarget = Random.Range(0, 5);

		if (chooseEnemyTarget == 0)
		{
			attackEnemy1 = true;
		}

		else if (chooseEnemyTarget == 1)
		{
			attackEnemy2 = true;
		}

		else if (chooseEnemyTarget == 2)
		{
			attackEnemy3 = true;
		}

		else if (chooseEnemyTarget == 3)
		{
			attackEnemy4 = true;
		}

		else if (chooseEnemyTarget == 4)
		{
			attackEnemy5 = true;
		}
	}
	public void resetState()
	{
		moveToEnemyBase1 = false;
		moveToEnemyBase2 = false;
		moveToEnemyBase3 = false;
		retreatToBase1 = false;
		retreatToBase2 = false;
		retreatToBase3 = false;
		attackEnemy1 = false;
		attackEnemy2 = false;
		attackEnemy3 = false;
		attackEnemy4 = false;
		attackEnemy5 = false;
	}

}


