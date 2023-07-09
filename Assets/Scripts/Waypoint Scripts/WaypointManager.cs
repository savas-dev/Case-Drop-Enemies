/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager instance;

    [Header("Settings")]
    public Transform[] waypoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}