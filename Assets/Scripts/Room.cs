using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isCleared = false;
    public GameObject nextCheckpoint;
    public Door door;
    public int buttonsToPress;

    private void Update()
    {
        if (buttonsToPress == 0)
            Clear();
    }
    void Clear()
    {
        if (!isCleared)
        {
            isCleared = true;
            GameManager.Instance.lastCheckpoint = nextCheckpoint;
            door.Open();
        }

    }
}
