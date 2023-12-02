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
        float dt = Time.deltaTime;
        float dx = speedX * dt;
        float dy = speedY * dt;
        float dz = speedZ * dt;

        transform.position += new Vector3(dx, dy, dz);
    }
}