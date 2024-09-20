using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorPrefab;
    public GameObject wall;

    private MeshRenderer renderer;
    private BoxCollider collider;

    private void Start()
    {
        DoorPrefab = gameObject;
        renderer = DoorPrefab.GetComponent<MeshRenderer>();
        collider = wall.gameObject.GetComponent<BoxCollider>();
    }
    public void Open()
    {
        renderer.enabled = false;
        collider.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            renderer.enabled = true;
            collider.enabled = true;
            GameManager.Instance.mainCamera.transform.position += new Vector3(0,0,20);
            GameManager.Instance.playerStats.currentHealth = GameManager.Instance.maxHealth;
        }
    }
}
