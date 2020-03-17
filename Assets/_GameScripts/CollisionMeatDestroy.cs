using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMeatDestroy : MonoBehaviour {

    //public GameObject player;
    //public int playerLife;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Meat")
        {
            Debug.Log("COLLISION WITH MEAT");
            Destroy(collidedWith);
        }
    }
}