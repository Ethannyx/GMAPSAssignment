using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    //Setting a space in the inspector to change the jump height (1f is just the default jump height)
    public float Height = 1f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v^2 = u^2 + 2as
        // u^2 = v^2 - 2as
        // u = sqrt(v^2 - 2as)

        //Calculate the gravity acting on each cube
        float gravity = Mathf.Abs(Physics.gravity.y);

        //Calculate the initial velocity to reach the desired height
        float u = Mathf.Sqrt(2f * gravity * Height);
        //Setting that velocity to the rigid body to make it move upwards in the y axis
        rb.velocity = new Vector3(0f, u, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Calling the method to move the cube upwards
            Jump();
        }
    }
}
