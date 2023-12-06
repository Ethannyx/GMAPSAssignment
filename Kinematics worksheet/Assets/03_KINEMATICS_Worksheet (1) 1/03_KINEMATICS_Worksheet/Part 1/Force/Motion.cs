using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public float speedX = 2f;
    public float speedY = 0f;
    public float speedZ = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get the time passed since the last frame
        float dt = Time.deltaTime;

        //calculating the change in position based on speed and time
        float dx = speedX * dt;
        float dy = speedY * dt;
        float dz = speedZ * dt;

        //Update the position of the ball based on the speed and time
        transform.position += new Vector3(dx, dy, dz);
    }
}