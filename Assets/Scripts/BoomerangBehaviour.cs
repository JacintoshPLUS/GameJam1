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
    public bool deadly;
    //private float waitTimer;
    void Start()
    {
        state = BoomerangState.Ready;
        rb = GetComponent<Rigidbody>();
        //waitTimer = 1f;
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
        //waitTimer = 1f;
    }

    private void Spin()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private void StopBoomerang()
    {
        if (transform.position.z >= StartPosition.z + range 
            || transform.position.x >= StartPosition.x + range
            || transform.position.z <= StartPosition.z - range
            || transform.position.x <= StartPosition.x - range)
        {
            state = BoomerangState.ReachedEnd;
            rb.velocity = Vector3.zero;
        }
    }

    public void MoveBoomerang()
    {
        Debug.Log("Boomerang thrown");
        StartPosition = transform.position;
        state = BoomerangState.Moving;
        rb.AddForce(GameManager.Instance.playerDirection * speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log(other.name);

        if(other == null || !other.transform.parent)
            return;
        else
        {
            Buttons b = other.GetComponent<Transform>().gameObject.GetComponent<Buttons>();
            EnemyMovement e = other.transform.parent.gameObject.GetComponent<EnemyMovement>();

            if (b != null)
            {
                b.Activate();
            }
            if (e != null)
            {
                if(deadly)
                    e.State = EnemyStates.dying;
            }
            Stop();
        }
    }
    private void Stop()
    {
        rb.velocity = Vector3.zero;
        state = BoomerangState.Returning;
    }
}
