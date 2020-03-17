using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnemySpearCollision : MonoBehaviour {

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "EnemySpear")
        {
            Destroy(gameObject);
            Debug.Log("Killed1");
        }
    }
}