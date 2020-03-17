using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Some of this code is from a tutorial which I went through creating a game called Apple Picker. The code causes the object it is placed on to move back and forth
    //while also spawning an object.

    public GameObject enemyPrefab;

    public float speed = 100f;

    public float leftAndRightEdge = 1000f;

    public float chanceToChangeDirections = 0.01f;

    public float secondsBetweenSpawns = 1f;

    void Start()
    {
        Invoke("spawnEnemy", 1f);
    }
    void spawnEnemy()
    {
        GameObject enemy = Instantiate<GameObject>(enemyPrefab);
        enemy.transform.position = transform.position;
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