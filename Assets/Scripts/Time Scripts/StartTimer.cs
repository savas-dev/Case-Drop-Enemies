/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class StartTimer : MonoBehaviour
{
    public static StartTimer instance;

    public float startTimeValue;
    public TextMeshProUGUI startTimeText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        // if leveltimevalue greater than 0, update count down
        if (startTimeValue > 0)
        {
            startTimeValue -= Time.deltaTime;
            ShowTime(startTimeValue);
        }
        else
        {
            startTimeValue = 0f;
            GameManager.instance.isGameStart = true;
            CameraController.instance.isFollowStart = true;

            // we catch all enemies and play anims
            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var item in enemy)
            {
                item.gameObject.GetComponent<EnemyAI>().UpdateDest();
                if (!GameManager.instance.isGameOver)
                {
                    item.gameObject.GetComponent<Animator>().Play("Walk2");
                }
            }
        }


        
    }

    public void ShowTime(float timeToShow)
    {
        if (timeToShow < 0)
        {
            timeToShow = 0f;
            
        }// if we want to not calculate 0 seconds, we can use this code. this code works for not calculate 0 seconds completly.
        else if (timeToShow > 0)
        {
            timeToShow += 1;
        }

        // calculate minutes
        //float minutes = Mathf.FloorToInt(timeToShow / 60);

        // calculate seconds
        float seconds = Mathf.FloorToInt(timeToShow % 60);

        // calculate mili seconds
        //float miliSeconds = timeToShow % 1 * 1000;

        // show time text with seconds type
        startTimeText.text = seconds.ToString();


        // Scale anim with dotween
        if (seconds == 3)
        {
            startTimeText.transform.DOScale(new Vector3(5f, 5f, 5f), .3f);
        }

        // Scale anim with dotween
        if (seconds == 2)
        {
            startTimeText.transform.DOScale(new Vector3(3f, 3f, 3f), .3f);
        }

        // Scale anim with dotween
        if (seconds == 1)
        {
            startTimeText.transform.DOScale(new Vector3(5f, 5f, 5f), .3f);
        }

        // we use dotween for scale animation
        if (seconds <= 0)
        {
            startTimeText.text = "GO!";
            startTimeText.transform.DOScale(new Vector3(7, 7, 7), .5f).
                OnComplete(() => startTimeText.transform.DOScale(new Vector3(0, 0, 0), .6f));

            // destroy start time object after game start
            Destroy(startTimeText.transform.parent.gameObject, 5f);

            DragAndMove.instance.StartAnim();
        }
        // without miliseconds
        //startTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // with miliseconds
        // levelTimeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliSeconds);
    }
}
