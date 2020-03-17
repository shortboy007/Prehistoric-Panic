using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroySpearOnCollision : MonoBehaviour
{

    //This script is meant to destroy the spear when it collides with anything else. There is also optional code commented out at the bottom which
    //allows the spear to split into smaller sections by spawning in smaller game objects such as fragments of wood.

    public GameObject splinter;

    public Random objectsToDrop;

    void Start()
    {
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.gameObject)
        {
            //spawn();
            Destroy(this.gameObject);
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);
        }
    }
    /*void spawn()
    {
        var objectsToDrop = Random.Range(0, 10);

            for (int i = 0; i < objectsToDrop; i++)
            {
                Instantiate(splinter, this.gameObject.transform.position, Quaternion.identity);
            }
    }*/
}