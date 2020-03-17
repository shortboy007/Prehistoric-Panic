using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyPlayerOnCollision : MonoBehaviour
{
    //This script handles how many times a player can get hit before they die. 
    //The player initially has ten life points. Each time the player gets hit with an enemy spear, an enemy or boss, one life point is taken away.
    //If a player loses all their life points, gravity is turned on and they are no longer kinematic. This causes a dramatic scene of the player falling out of the sky.
    //If the player collides with meat, their life points are increased by one. 
    //The player can collect as much health as they want before the end of the level, depending on how much spawns.

	public GameObject player;
    public GameObject playerBonePrefab;
   //public GameObject menu;
    public Transform target;
    public int bonesToDrop = 1;

    public int playerLife = 10;

    public GameObject textBox;
    public Text text;

    void Start()
	{
		player = GameObject.FindWithTag("Player");
        textBox = GameObject.FindWithTag("TextBoxLife");
        //menu = GameObject.FindWithTag("Menu");
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject collidedWith = other.gameObject;
        if (collidedWith.tag == "EnemySpear" || collidedWith.tag == "Enemy" || collidedWith.tag == "EnemyBoss" || collidedWith.tag == "Bone" || collidedWith.tag == "Raptor" || collidedWith.tag == "Tentacle")
        {
            Debug.Log("COLLISION WITH Enemy");
            playerLife -= 1;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hurtPlayer);

        }

        if (collidedWith.tag == "Meat")
        {
            Debug.Log("COLLISION WITH MEAT");
            Destroy(collidedWith);
            playerLife = playerLife + 1;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.playerPickupMeat);
        }

        text = textBox.GetComponent<Text>();
            text.text = "Player Life: " + playerLife;
        }

        void Update()
    {
        if (playerLife <= 0)
        {
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<Rigidbody>().useGravity = true;

            Destroy(gameObject, 5f);
            //spawn();

            //menu.GetComponent<Canvas>().enabled = true;

            //StartCoroutine("restartLevel", 5f);     
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.playerDeath);
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.pterodactylRoar);
        }
    }

    /*IEnumerator restartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        SceneManager.LoadScene("LevelSelect");
        yield return new WaitForSeconds(5.0f);
    }*/

    void spawn()
    {
        for (int i = 0; i < bonesToDrop; i++)
        {
            Instantiate(playerBonePrefab, target.transform.position, Quaternion.identity);
        }
    }
}