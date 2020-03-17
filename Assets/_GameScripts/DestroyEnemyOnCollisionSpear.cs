using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemyOnCollisionSpear : MonoBehaviour
{

    //This script is a more complicated version of the script which keeps track of score or how many enemies the player has killed.
    //The score is held in a static int which is updated on a text object inside of a canvas each time a collision is recorded.

    public EnemyCounter enemyCounter;

    public GameObject enemy;
    public GameObject enemyGroundSpawner;
    public GameObject bonePrefab;
    public GameObject meatPrefab;
    public int objectsToDrop = 1;
    public static int playerScore = 0;
    public static int raptorsKilled = 0;
    public static int tentaclesKilled = 0;
    public static int lizardsKilled = 0;
    public GameObject textBox;
    public Text text;

    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        textBox = GameObject.FindWithTag("TextBoxScore");

        enemyGroundSpawner = GameObject.FindWithTag("SpawnerGround");
    }

    void Update()
    {
        //This checks if the groundspawner object exists in the game.
        //If it does, this script reads from a script on it which counts how many of a specific type of enemy has been killed.
        //This spawner is used for bosses such as the raptors in the forest level and the tentacles of the octopus in the water level.
        //The Enemy Counter Script counts how many of these special enemies have been killed and then after a certain amount, executes code.

        if (enemyGroundSpawner != null)
        {
            enemyGroundSpawner = GameObject.FindWithTag("SpawnerGround");
            enemyGroundSpawner.GetComponent<EnemyCounter>();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Spear" || collidedWith.tag == "Debris")
        {
            spawn();
            Destroy(gameObject);
            
            playerScore = playerScore + 1;
            text = textBox.GetComponent<Text>();
            text.text = "Score: " + playerScore;   

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);

            if(gameObject.tag == "Raptor")
            {           
                EnemyCounter.raptorsKilled = EnemyCounter.raptorsKilled + 1;
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.tyrannosaurusRoar);
            }

            if (gameObject.tag == "Tentacle")
            {
                EnemyCounter.tentaclesKilled = EnemyCounter.tentaclesKilled + 1;
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.tyrannosaurusRoar);
            }

            if (gameObject.tag == "Lizard")
            {
                EnemyCounter.lizardsKilled = EnemyCounter.lizardsKilled + 1;
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.tyrannosaurusRoar);
            }

            if (gameObject.tag == "Enemy")
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.enemyDeath);
            }
        }
    }

    //This method chooses randomly between four options of what to drop when an enemy dies. 
    //There are two chances to drop a bone and also two chances to drop meat which heals the player.
    void spawn()
    {
        var chooseDrop = Random.Range(0, 3);

        if (chooseDrop == 0)
        {
            for (int i = 0; i < objectsToDrop; i++)
            {
                Instantiate(bonePrefab, transform.position, Quaternion.identity);
            }
        }

        if (chooseDrop == 1)
        {
            for (int i = 0; i < objectsToDrop; i++)
            {
                Instantiate(bonePrefab, transform.position, Quaternion.identity);
            }
        }

        else if (chooseDrop == 2)
        {
            for (int i = 0; i < objectsToDrop; i++)
            {
                Instantiate(meatPrefab, transform.position, Quaternion.identity);
            }
        }

        else if (chooseDrop == 3)
        {
            for (int i = 0; i < objectsToDrop; i++)
            {
                Instantiate(meatPrefab, transform.position, Quaternion.identity);
            }
        }

    }
}