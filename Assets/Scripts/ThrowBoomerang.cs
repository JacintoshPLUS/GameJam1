using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBoomerang : MonoBehaviour
{
    public GameObject Boomerang;
    public BoomerangBehaviour b;
    // Start is called before the first frame update
    void Start()
    {
        if (Boomerang == null)
            Debug.Log("Player has no boomerang");
        b = Boomerang.GetComponent<BoomerangBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && b.state == BoomerangState.Ready)
        {
            b.state = BoomerangState.Throw;
        }
    }

    private void MoveBoomerang()
    {

    }
}
