using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isCleared = false;

    private void OnTriggerExit(Collider other)
    {
        if(!isCleared)
            isCleared = true;
    }
}
