using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
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

        float gravity = Mathf.Abs(Physics.gravity.y);
        float u = Mathf.Sqrt(2f * gravity * Height);
        rb.velocity = new Vector3(0f, u, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
