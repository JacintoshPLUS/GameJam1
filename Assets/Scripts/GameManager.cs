using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        playerDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
