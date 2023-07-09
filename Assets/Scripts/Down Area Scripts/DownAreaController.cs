/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DownAreaController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy geldi");
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            other.gameObject.GetComponent<EnemyAI>().enabled = false;
            other.gameObject.GetComponent<EnemyController>().SetConstraints();
            Destroy(other.gameObject, 2f);
        }
    }
}
