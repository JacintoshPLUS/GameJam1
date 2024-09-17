using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoomerangBehaviour : MonoBehaviour
{
    public BoomerangState state;
    public GameObject player;
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
            StartCoroutine(WaitForReturn());
            Spin();
        }
        if (state == BoomerangState.Returning)
        {
            ReturnBoomerang();
            Spin();
        }
    }

    private void ReturnBoomerang()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(transform.position == player.transform.position)
        {
            state = BoomerangState.Ready;
        }
    }

    private IEnumerator WaitForReturn()
    {
        yield return new WaitForSeconds(1f);
        state = BoomerangState.Returning;
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
