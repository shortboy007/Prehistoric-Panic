using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBossEnemyOnCollisionSpear : MonoBehaviour
{
    //This script handles how many times a boss can be hit before it dies. Whenever the boss collides with a spear, one int value is added to the boss hits int.
    //When the boss gets three hits, it dies and is destroyed. It also spawns a few bones when it dies.

    public GameObject bonePrefab;
    public Transform target;
    public int bonesToDrop = 2;
    public int bossHits = 0;

    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Spear")
        {
            bossHits++;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hit);

        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (bossHits >=3)
        {
            Destroy(gameObject);
            spawn();
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.tyrannosaurusRoar);
        }
    }

    void spawn()
    {
        for (int i = 0; i < bonesToDrop; i++)
        {
            Instantiate(bonePrefab, target.transform.position, Quaternion.identity);
        }
        
    }
}