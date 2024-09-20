using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementSimple : MonoBehaviour
{
    Rigidbody body;
    public Rigidbody br;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        UpdateDirection();

        if (GameManager.Instance.gameState == GameStates.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.RestartPuzzle();
            }
        }
    }

    private void UpdateDirection()
    {
        if (Input.GetKeyDown(KeyCode.W))
            GameManager.Instance.playerDirection = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.A))
            GameManager.Instance.playerDirection = Vector3.left;
        if (Input.GetKeyDown(KeyCode.S))
            GameManager.Instance.playerDirection = Vector3.back;
        if (Input.GetKeyDown(KeyCode.D))
            GameManager.Instance.playerDirection = Vector3.right;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector3(horizontal * runSpeed,0, vertical * runSpeed).normalized * 10;
        if(body.GetComponent<ThrowBoomerang>().b.state == BoomerangState.Ready)
        {
            br.velocity = new Vector3(horizontal * runSpeed, 0, vertical * runSpeed).normalized * 10;
        }
    }
}
