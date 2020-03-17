using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSpearCollision : MonoBehaviour {

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "CivilianSpear")
        {
            Destroy(gameObject);
            Debug.Log("Killed2");
        }
    }
}