/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public Rigidbody enemyRigid;
    public int enemyScore;
    public float enemyForcePower;
    public bool isEnemyDie;
    public Animator enemyAnim;
    public GameObject enemyInstance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRigid = GetComponent<Rigidbody>();
        enemyScore = 0;
    }

    public void IncreaseEnemyScore(int scoreValue)
    {
        enemyScore += scoreValue;
    }

    public void IncreaseEnemyForcePower(float forceValue)
    {
        enemyForcePower += forceValue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy, enemye çarptı");
            // add force to enemy and player opposite position
            Vector3 dir = collision.transform.position - transform.position;
            dir.Normalize();
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * enemyForcePower, ForceMode.Impulse);

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


            GetComponent<NavMeshAgent>().enabled = false;
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            Debug.Log("Player, enemye çarptı");
            // add force to enemy and player opposite position
            Vector3 dir = collision.transform.position - transform.position;
            dir.Normalize();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * enemyForcePower, ForceMode.Impulse);
            Invoke(nameof(OpenCharacterController), .2f);
            Invoke(nameof(OpenNavMesh), 5f);
            Invoke(nameof(SetConstraints), .5f);

        }
    }

    // we use invoke method for reset rigidbody constraints
    public void SetConstraints()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void OpenCharacterController()
    {
        PlayerController.instance.GetComponent<CharacterController>().enabled = true;
    }

    public void OpenNavMesh()
    {
        GetComponent<NavMeshAgent>().enabled = true;
    }

    public void PlayEnemyRun()
    {
        if (GetComponent<Animator>().isActiveAndEnabled)
        {
            enemyAnim.Play("Run");
        }
    }
}
