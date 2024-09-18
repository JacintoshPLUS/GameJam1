using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates gameState;

    public Vector3 playerDirection;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerDirection = Vector3.forward;
        gameState = GameStates.running;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && gameState == GameStates.running)
            Death();
    }

    private void Death()
    {
        Time.timeScale = 0;
        gameState = GameStates.gameOver;
        Debug.Log("Game Over :(");
    }
}
