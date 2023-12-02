using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the GameObject
        rb.AddForce(new Vector3(500f, 0f, 0f)); // Apply force along the X-axis
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

