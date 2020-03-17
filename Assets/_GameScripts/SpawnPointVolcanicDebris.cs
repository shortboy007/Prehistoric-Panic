using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointVolcanicDebris : MonoBehaviour
{
    public GameObject volcanicDebrisPrefab;
    public GameObject player;
    public bool nearPlayer = false;

    void Start()
    {
        //volcanicDebrisPrefab = GameObject.FindWithTag("Debris");
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(distToPlayer);

        if (distToPlayer <= 1000.0f)
        {
            nearPlayer = true;
        }
        else
        {
            nearPlayer = false;
        }

        if (nearPlayer)
        {
            Invoke("debrisSpawn", 2f);
        }
    }
    void debrisSpawn()
    {
        GameObject debris = Instantiate(volcanicDebrisPrefab) as GameObject;
        debris.transform.position = transform.position;
        Destroy(debris, 10.0f);
    }
    }