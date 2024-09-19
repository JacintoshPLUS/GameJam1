using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyStates State = EnemyStates.standing;
    public float speed;
    public float range;
    public float frequency;
    public GameObject characterModel;
    private float timer;
    private Vector3 startPosition;
    private bool flipped;

    private void Start()
    {
        characterModel = transform.GetChild(0).gameObject;
        if (characterModel == null)
            Debug.Log("Enemy has no model");
        startPosition = characterModel.transform.position;
        flipped = false;
        Debug.Log(startPosition);
    }

    private void Update()
    {
        if (State == EnemyStates.leftRight)
        {
            Move();
        }
        if(State == EnemyStates.appearing)
        {
            Teleport();
        }
        if(State == EnemyStates.dying)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void Teleport()
    {
        timer += Time.deltaTime;
        if (timer >= frequency)
        {
            characterModel.SetActive(!characterModel.activeSelf);
            timer = 0;
        }
    }

    private void Move()
    {
        if (!flipped) 
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(0 - speed * Time.deltaTime, 0, 0));
        }
        CheckPosition();
    }
    private void CheckPosition()
    {
        if(transform.position.x >= startPosition.x + range || transform.position.z <= startPosition.z - range)
        {
            flipped = true;
        }
        if(transform.position.x <= startPosition.x - range || transform.position.z >= startPosition.z + range)
        {
            flipped = false;
        }
    }
}
