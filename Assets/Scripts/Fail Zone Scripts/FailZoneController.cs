/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FailZoneController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            collision.gameObject.GetComponent<EnemyController>().isEnemyDie = true;
            IncreaseScore(500);
            GameManager.instance.stickmanList.Remove(collision.gameObject);
            GameManager.instance.stickmanCountText.text = GameManager.instance.stickmanList.Count.ToString();
            Destroy(collision.gameObject, .2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreCollector"))
        {
            GameManager.instance.isGameOver = true;
            GameManager.instance.GameOverDelay();
            Debug.Log("oyun bitti");
        }

        if (other.gameObject.CompareTag("EnemyScoreCollector"))
        {
            other.transform.parent.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.transform.parent.gameObject.GetComponent<EnemyController>().isEnemyDie = true;
            IncreaseScore(500);
            GameManager.instance.stickmanList.Remove(other.transform.parent.gameObject);
            GameManager.instance.stickmanCountText.text = GameManager.instance.stickmanList.Count.ToString();
            Destroy(other.transform.parent.gameObject, .2f);

            if(GameManager.instance.stickmanList.Count <= 1)
            {
                GameManager.instance.isGameWin = true;
                GameManager.instance.WinDelay();
            }
        }
    }


    // if enemy fall to water, player score increase and enemy remove the list
    public void IncreaseScore(int scoreValue)
    {
        GameManager.instance.score += scoreValue;
        GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
        
    }
}
