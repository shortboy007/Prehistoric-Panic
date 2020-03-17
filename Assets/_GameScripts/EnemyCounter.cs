using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour 
{
    //This script keeps track of how many boss monsters have been killed. When 20 raptors, tentacles, or lizards have been killed, certain code executes.

    public DestroyEnemyOnCollisionSpear DEOCS;

    public GameObject enemyGroundSpawner;

    public GameObject Octopus;

    public GameObject Object1;

    public GameObject Object2;

    public static int raptorsKilled = 0;// = DestroyEnemyOnCollisionSpear.raptorsKilled;

    public static int tentaclesKilled = 0;

    public static int lizardsKilled = 0;

    void Start()
    {
        enemyGroundSpawner = GameObject.FindWithTag("SpawnerGround");        
    }

    void Update()
    {
        Debug.Log("Raptors Killed: " + raptorsKilled);
        Debug.Log("Tentacles Killed: " + tentaclesKilled);
        Debug.Log("Lizards Killed: " + lizardsKilled);

        //When all conditions are met and 20 of a certain boss type are killed, the enemygroundspawner object which this script is on gets destroyed.
        //The octupus changes its AI and also becomes killable once any of its tentacles are defeated 20 times.
        //The lizards are from the volcano level and when they are killed, the particle effects of the volcano eruption stops when the objects are destroyed.
        if (raptorsKilled == 20)
        {
            Destroy(this.gameObject);
        }        
        if (tentaclesKilled == 20)
        {
                Octopus.GetComponent<SphereCollider>().enabled = true;
                Octopus.GetComponent<DestroyBossEnemyOnCollisionSpear>().enabled = true;
                Octopus.GetComponent<RiseAndLowerScript>().enabled = false;
                Octopus.GetComponent<RiseAndLowerScriptBoss>().enabled = true;
                Destroy(this.gameObject);
        }
        if (lizardsKilled == 20)
        {
            Destroy(Object1);
            Destroy(Object2);
            Destroy(this.gameObject);
        }
    }
}
