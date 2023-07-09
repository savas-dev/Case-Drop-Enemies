/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public static LevelTimer instance;

    public float levelTimeValue;
    public TextMeshProUGUI levelTimeText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        // we show leveltimevalue on game start becuase we calculate mines 1 for correct time show
        ShowTime(levelTimeValue - 1f);
    }

    private void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            // if leveltimevalue greater than 0, update count down
            if (levelTimeValue > 0)
            {
                levelTimeValue -= Time.deltaTime;
            }
            else
            {
                levelTimeValue = 0f;
                GameManager.instance.isGameStart = false;
                GameManager.instance.GameOverDelay();
            }


            ShowTime(levelTimeValue);
        }
    }

    public void ShowTime(float timeToShow)
    {
        if(timeToShow < 0)
        {
            timeToShow = 0f;
        }// if we want to not calculate 0 seconds, we can use this code. this code works for not calculate 0 seconds completly.
        else if (timeToShow > 0)
        {
            timeToShow += 1;
        }

       // calculate minutes
        float minutes = Mathf.FloorToInt(timeToShow / 60);
        // calculate seconds
        float seconds = Mathf.FloorToInt(timeToShow % 60);
        // calculate mili seconds
        float miliSeconds = timeToShow % 1 * 1000;

        // without miliseconds
        levelTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // with miliseconds
        // levelTimeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliSeconds);
    }
}
