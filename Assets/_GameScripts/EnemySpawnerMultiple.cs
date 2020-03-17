using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMultiple : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public float speed = 100f;

    public float leftAndRightEdge = 200f;

    public float chanceToChangeDirections = 0.01f;

    public float secondsBetweenSpawns = 1f;

    void Start()
    {
        Invoke("spawnEnemy", 1f);
    }
    void spawnEnemy()
    {
        var chooseEnemy = Random.Range(0, 4);

        if (chooseEnemy == 0)
        {
            GameObject eP1 = Instantiate<GameObject>(enemy1);
            eP1.transform.position = transform.position;
        }

        else if (chooseEnemy == 1)
        {
            GameObject eM2 = Instantiate<GameObject>(enemy2);
            eM2.transform.position = transform.position;
        }

        else if (chooseEnemy == 2)
        {
            GameObject eF3 = Instantiate<GameObject>(enemy3);
            eF3.transform.position = transform.position;
        }

        else if (chooseEnemy == 3)
        {
            GameObject eW4 = Instantiate<GameObject>(enemy4);
            eW4.transform.position = transform.position;
        }

        else if (chooseEnemy == 4)
        {
            GameObject eS5 = Instantiate<GameObject>(enemy5);
            eS5.transform.position = transform.position;
        }

        Invoke("spawnEnemy", secondsBetweenSpawns);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}