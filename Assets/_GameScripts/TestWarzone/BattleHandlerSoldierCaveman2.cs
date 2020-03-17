using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandlerSoldierCaveman2 : MonoBehaviour
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

    public GameObject sword;

    public GameObject army1Base;
    public GameObject army1Base2;
    public GameObject army1Base3;

    public GameObject army2Base;
    public GameObject army2Base2;
    public GameObject army2Base3;

    public bool closeToEnemySoldier = false;


    public bool tooFarFromEnemySoldier = false;
    public bool followingPlayer = false;
    public float moveSpeed;

	public float normalSpeed = 30.0f;

	public float attackSpeed = 35.0f;

	public float fleeSpeed = 40.0f;

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
		var chooseBaseTarget = Random.Range(0, 2);

		moveSpeed = normalSpeed;

		if (chooseBaseTarget == 0)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army1Base.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy1Base = new Vector3(army1Base.transform.position.x,
            transform.position.y, army1Base.transform.position.z);
            transform.LookAt(rotateTowardarmy1Base);*/
		}
		else if (chooseBaseTarget == 1)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army1Base2.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy1Base2 = new Vector3(army1Base2.transform.position.x,
            transform.position.y, army1Base2.transform.position.z);
            transform.LookAt(rotateTowardarmy1Base2);*/
		}
		if (chooseBaseTarget == 2)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			army1Base3.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy1Base3 = new Vector3(army1Base3.transform.position.x,
            transform.position.y, army1Base3.transform.position.z);
            transform.LookAt(rotateTowardarmy1Base3);*/
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

		if (distToEnemy1 <= 2000.0f || distToEnemy2 <= 2000.0f || distToEnemy3 <= 2000.0f || distToEnemy4 <= 2000.0f || distToEnemy5 <= 2000.0f)
		{
			closeToEnemySoldier = true;
			tooFarFromEnemySoldier = false;
		}
		else if (distToEnemy1 >= 600.0f || distToEnemy2 >= 600.0f || distToEnemy3 >= 600.0f || distToEnemy4 >= 600.0f || distToEnemy5 >= 600.0f)
		{

			tooFarFromEnemySoldier = true;
			closeToEnemySoldier = false;
		}

		if (tooFarFromEnemySoldier)
		{
			chooseInitialTarget ();
		}

		else if (closeToEnemySoldier)
		{
			fight ();
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

		moveSpeed = fleeSpeed;

		var chooseBaseRetreatTarget = Random.Range(0, 2);

		if (chooseBaseRetreatTarget == 0)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				army2Base.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy2Base = new Vector3(army2Base.transform.position.x,
            transform.position.y, army2Base.transform.position.z);
            transform.LookAt(rotateTowardarmy2Base);*/
		}
		else if (chooseBaseRetreatTarget == 1)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				army2Base2.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy2Base2 = new Vector3(army2Base2.transform.position.x,
            transform.position.y, army2Base2.transform.position.z);
            transform.LookAt(rotateTowardarmy2Base2);*/
		}
		if (chooseBaseRetreatTarget == 2)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				army2Base3.transform.position, Time.deltaTime * moveSpeed);
			/*Vector3 rotateTowardarmy2Base3 = new Vector3(army2Base3.transform.position.x,
            transform.position.y, army2Base3.transform.position.z);
            transform.LookAt(rotateTowardarmy2Base3);*/
		}


	}

	void fight()
	{
		Debug.Log("fight2");

		moveSpeed = attackSpeed;

		var chooseEnemyTarget = Random.Range(0, 5);

		float distToEnemy1 = Vector3.Distance(transform.position, enemy1.transform.position);
		float distToEnemy2 = Vector3.Distance(transform.position, enemy2.transform.position);
		float distToEnemy3 = Vector3.Distance(transform.position, enemy3.transform.position);
		float distToEnemy4 = Vector3.Distance(transform.position, enemy4.transform.position);
		float distToEnemy5 = Vector3.Distance(transform.position, enemy5.transform.position);


		if (distToEnemy1 <= 2000.0f && chooseEnemyTarget == 0)
		{
			transform.position = Vector3.MoveTowards(transform.position,
			enemy1.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier1 = new Vector3(enemy1.transform.position.x,
			transform.position.y, enemy1.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier1);
		}

		else if (distToEnemy2 <= 2000.0f && chooseEnemyTarget == 1)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy2.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier2 = new Vector3(enemy2.transform.position.x,
				transform.position.y, enemy2.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier2);
		}

		else if (distToEnemy3 <= 2000.0f && chooseEnemyTarget == 2)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy3.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier3 = new Vector3(enemy3.transform.position.x,
				transform.position.y, enemy3.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier3);
		}

		else if (distToEnemy4 <= 2000.0f && chooseEnemyTarget == 3)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy4.transform.position, Time.deltaTime * moveSpeed);Vector3 rotateTowardEnemySoldier4 = new Vector3(enemy4.transform.position.x,
				transform.position.y, enemy4.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier4);
		}

		else if (distToEnemy5 <= 2000.0f && chooseEnemyTarget == 4)
		{
			transform.position = Vector3.MoveTowards(transform.position,
				enemy5.transform.position, Time.deltaTime * moveSpeed);
			Vector3 rotateTowardEnemySoldier5 = new Vector3(enemy5.transform.position.x,
				transform.position.y, enemy5.transform.position.z);
			transform.LookAt(rotateTowardEnemySoldier5);
		}
	}
}



