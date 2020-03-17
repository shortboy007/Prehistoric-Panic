using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaObjectSpawnHandler : MonoBehaviour
{
    //This is a script which I borrowed from an MLAgents project. 
    //When placed on an object, this script originally would spawn specific objects at the time of its activation in a specific range.
    //I changed the script so that instead of using the specific range, the objects would spawn based on the dimensions of the object the script was on.
    //I used this to spawn camps in the plains level and trees in the forest and volcano level.

    public GameObject spawnObject;
    public int spawnObjects;
    //public float range;
    public float height = 10f;

    public GameObject area;

    // Use this for initialization
    void Start()
    {

        CreateObjects(spawnObjects, spawnObject);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            CreateObjects(spawnObjects, spawnObject);
        }
    }

    void CreateObjects(int numObjects, GameObject objectType)
    {
        for (int i = 0; i < numObjects; i++)
        {
            /*GameObject objects = Instantiate(objectType, new Vector3(Random.Range(-range, range), 1f,
                                                               Random.Range(-range, range)) + transform.position,
                                           Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f)));*/

            GameObject objects = Instantiate(objectType, new Vector3(Random.Range(-transform.localScale.x, transform.localScale.x), height,
                                                                  Random.Range(-transform.localScale.z, transform.localScale.z)) + transform.position,
                                              Quaternion.Euler(new Vector3(0f, Random.Range(0f, 360f), 0f)));
        }
    }

    public void ResetArea()
    {
    }
}
