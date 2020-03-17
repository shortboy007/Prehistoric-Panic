using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightCameraFollow : MonoBehaviour
{
    //This code makes the camera follow the player at a specific vector offset which can be set in the inspector.

    public Transform followTarget;
    public float moveSpeed = 20;
    public Vector3 offset = new Vector3(0f, 3f, -10.0f);

    // Update is called once per frame
    /*void Update()
     {
         /if (followTarget != null)
         {
             transform.position = Vector3.Lerp(transform.position + offset, followTarget.transform.position, Time.deltaTime * moveSpeed);
         }

     }*/

    void Start()
    {
        followTarget = GameObject.FindWithTag("Player").transform;
    }

        private void LateUpdate()
    {
        transform.position = followTarget.position + offset;             
    }
}
