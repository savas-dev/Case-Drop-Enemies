/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerCubeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // if player touch this object, add score and destroy this gameobject
        if (other.gameObject.CompareTag("ScoreCollector"))
        {
            GameManager.instance.IncreaseScore(100);

            // Increase player transform scale
            PlayerController.instance.IncreaseForcePower(2f);
            PlayerController.instance.transform.DOScale(new Vector3(
                PlayerController.instance.transform.localScale.x + .15f,
                PlayerController.instance.transform.localScale.y + .15f,
                PlayerController.instance.transform.localScale.z + .15f),
                .2f);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("EnemyScoreCollector"))
        {
            other.transform.parent.GetComponent<EnemyController>().IncreaseEnemyScore(100);

            // Increase player transform scale
            other.transform.parent.GetComponent<EnemyController>().IncreaseEnemyForcePower(2f);
            other.transform.parent.transform.DOScale(new Vector3(
                other.transform.parent.localScale.x + .10f,
                other.transform.parent.localScale.y + .10f,
                other.transform.parent.localScale.z + .10f),
                .2f);
            Destroy(this.gameObject);
        }
    }
}
