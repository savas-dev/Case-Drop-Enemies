/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCubeSpawner : MonoBehaviour
{
    public GameObject powerCube;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerCube), 4f, 1.2f);
    }

    // spawn power cubes random positions
    public void SpawnPowerCube()
    {
        Vector3 randomVector = new Vector3(Random.Range(-6f, 9f), Random.Range(5f, 10f), Random.Range(-7f, 8f));
        GameObject pc = Instantiate(powerCube, randomVector, Quaternion.identity);
    }

    
}
