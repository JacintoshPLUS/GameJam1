using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName ="ScriptableObjects/Data/PlayerData")]
public class PlayerStats : ScriptableObject
{
    public int deaths;
    public int currentHealth;
}
