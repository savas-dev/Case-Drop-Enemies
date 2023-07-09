/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI instance;

    [Header("Settings")]
    public Transform[] waypoints;
    public int waypointIndex;
    public Vector3 target;
    public NavMeshAgent agent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //UpdateDest();

        // we set waypoints poisitons randomly
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].transform.position = new Vector3(Random.Range(-4f, 6f), waypoints[i].transform.position.y, Random.Range(-10f, 7f));
        }
    }

    private void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            // enemy position less than 1 waypoint, update new destination
            if (Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDest();
            }
        }
    }

    public void UpdateDest()
    {
        target = waypoints[waypointIndex].position;
        if (GetComponent<NavMeshAgent>().isActiveAndEnabled)
        {
            // set destination to agent
            agent.SetDestination(target);
        }
    }

    public void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            // reset waypoint index to restart again
            waypointIndex = 0;
        }
    }

}
