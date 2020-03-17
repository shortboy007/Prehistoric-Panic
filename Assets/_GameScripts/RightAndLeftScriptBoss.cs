using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAndLeftScriptBoss : MonoBehaviour
{
    //Some of this code is from a tutorial which I went through creating a game called Apple Picker. The code causes the object it is placed on to move back and forth.
    //I use this code for some of the boss AI in order to make the boss move randomly in each direction.

    public float speed = 100f;

    public float leftAndRightEdge = 1000f;

    public float chanceToChangeDirections = 0.01f;

    public bool hitFloor;

    void Start()
    {
        hitFloor = false;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (hitFloor)
        {
            speed *= -1;
            hitFloor = false;
        }

        /*if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }*/
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.gameObject.tag == "Terrain")
        {
            hitFloor = true;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);
        }
    }

    void OnCollisionExit(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.gameObject.tag == "Terrain")
        {            
            hitFloor = false;           
        }
    }
}