using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameStates gameState;

    public Vector3 playerDirection;
    public int maxHealth;
    public Room[] rooms;
    public Room currentRoom;
    public PlayerStats playerStats;
    public GameObject player;
    public GameObject lastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerDirection = Vector3.forward;
        gameState = GameStates.running;
        playerStats.currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.currentHealth <= 0 && gameState == GameStates.running)
            Death();

    }

    private void Death()
    {
        Time.timeScale = 0;
        gameState = GameStates.gameOver;
        Debug.Log("Game Over :(");
    }

    public void RestartPuzzle()
    {
        player.transform.position = lastCheckpoint.transform.position;
        playerStats.deaths++;
        gameState = GameStates.running;
        Time.timeScale = 1f;
        playerStats.currentHealth = maxHealth;
    }
}
