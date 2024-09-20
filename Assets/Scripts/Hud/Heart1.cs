using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart1 : MonoBehaviour
{

    GameObject heart1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      if (GameManager.Instance.playerStats.currentHealth == 6)
        {
            heart1.SetActive(true);
        }
      else
      {
            heart1.SetActive(false);
        }
            
    }
}
