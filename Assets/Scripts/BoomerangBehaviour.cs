using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangBehaviour : MonoBehaviour
{
    public BoomerangState state;
    public Rigidbody rb;
    public Vector3 StartPosition;
    void Start()
    {
        state = BoomerangState.Ready;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == BoomerangState.Throw)
        {
            MoveBoomerang();
        }
        if (state == BoomerangState.Moving)
        {
            StopBoomerang();
        }
    }

    private void StopBoomerang()
    {
        if (transform.position.z >= StartPosition.z + 10)
            rb.velocity = Vector3.zero;
    }

    public void MoveBoomerang()
    {
        Debug.Log("Boomerang thrown");
        StartPosition = transform.position;
        state = BoomerangState.Moving;
        rb.AddForce(new Vector3(0, 0, 5), ForceMode.Impulse);
    }
}
