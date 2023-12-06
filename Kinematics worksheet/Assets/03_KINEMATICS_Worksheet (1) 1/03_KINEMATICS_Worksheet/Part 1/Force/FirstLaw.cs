using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        //Adding a force along the x axis (pushing left side of sphere)
        rb.AddForce(new Vector3(500f, 0f, 0f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}

