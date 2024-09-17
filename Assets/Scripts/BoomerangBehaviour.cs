using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoomerangBehaviour : MonoBehaviour
{
    public BoomerangState state;
    private Rigidbody rb;
    private Vector3 StartPosition;
    public int speed;
    public int range;
    public int rotationSpeed;
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
            Spin();
        }
        if (state == BoomerangState.ReachedEnd)
        {
            StartCoroutine(ReturnBoomerang());
            Spin();
        }
    }

    private void MoveBoomerangBack()
    {
    }

    private IEnumerator ReturnBoomerang()
    {
        yield return new WaitForSeconds(1f);
        state = BoomerangState.Returning;
        transform.position = Vector3.MoveTowards(transform.position, StartPosition, 10f);
        state = BoomerangState.Ready;
    }

    private void Spin()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void StopBoomerang()
    {
        if (transform.position.z >= StartPosition.z + range)
        {
            rb.velocity = Vector3.zero;
            state = BoomerangState.ReachedEnd;
        }
    }

    public void MoveBoomerang()
    {
        Debug.Log("Boomerang thrown");
        StartPosition = transform.position;
        state = BoomerangState.Moving;
        rb.AddForce(new Vector3(0, 0, speed), ForceMode.Impulse);
    }
}
