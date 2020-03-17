using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnCollisionSpear : MonoBehaviour
{
    //This script is a simpler version of the script which keeps track of score or how many enemies the player has killed. 
    //It lacks the functionality of the other script which spawns meat or bones when enemies are hit.
    //This script is used on targets for the practice mode.
    //The score is held in a static int which is updated on a text object inside of a canvas each time a collision is recorded.

    public static int playerScore = 0;
    public GameObject textBox;
    public Text text;

    void Start()
    {
        textBox = GameObject.FindWithTag("TextBoxScore");
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Spear" || collidedWith.tag == "Debris")
        {
            Destroy(gameObject);
            
            playerScore = playerScore + 1;
            text = textBox.GetComponent<Text>();
            text.text = "Score: " + playerScore;   

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);
        }
    }
}