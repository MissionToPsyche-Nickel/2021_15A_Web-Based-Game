using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script stores all the power-up prefabs and spawning locations.
// Put the power up in the array and it will appear in one of the spawning
// locations

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpList;
    public Transform[] spawnLocations;
    public float spawnTime = 2f;
    public float firstAppearance = 4f;
    public float rateOfSpawn = 20f;
    public int range;

    void Start()
    {
        // repeats function call every certain seconds after an initial certain seconds
        InvokeRepeating(nameof(SpawnPowerUp),firstAppearance, rateOfSpawn);
    }
    
    void SpawnPowerUp()
    {
        Instantiate(powerUpList[Random.Range(0, powerUpList.Length)], 
            spawnLocations[Random.Range(5, 5)]);
        SoundManager.instance.PlaySound("PowerUp");
    }
}
