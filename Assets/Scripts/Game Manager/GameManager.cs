/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Elements")]
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public TextMeshProUGUI rankText;

    [Header("Game Settings")]
    public bool isGameStart;
    public bool isGameOver;
    public bool isGameWin;
    public List<GameObject> stickmanList;
    public GameObject player;
    public GameObject[] enemies;
    public TextMeshProUGUI stickmanCountText;
    public TextMeshProUGUI scoreText;
    public int score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        // we define player and enemies gameobjects at start.
        // than, find player with tag
        // than find enemies, with tag of all enemies at the scene
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // added player and all enemies to list
        stickmanList.Add(player);


        // add all enemies to stickman list
        foreach (var item in enemies)
        {
            stickmanList.Add(item);
        }


        // added stickmanlist count to stickman count text
        stickmanCountText.text = stickmanList.Count.ToString();

        // score text = 0 on start
        score = 0;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        
    }

    // increase score value from powercubecontroller scripts
    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = score.ToString();
    }


    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        //Invoke(nameof(StopTime), 1f);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        rankText.text = "You Are " + stickmanList.Count.ToString() + ".";
        Time.timeScale = 0f;

    }

    public void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }

    // use delay with invoke method for watching anims
    public void GameOverDelay()
    {
        EnemyDance();
        player.GetComponent<Animator>().Play("Idle");
        Invoke(nameof(GameOver), 4f);
    }

    // use delay with invoke method for watching anims
    public void WinDelay()
    {
        PlayerDance();
        Invoke(nameof(Win), 4f);
    }

    public void EnemyDance()
    {
        foreach (var item in enemies)
        {
            item.GetComponent<Animator>().Play("Dance");
        }
    }

    public void PlayerDance()
    {
        player.GetComponent<Animator>().Play("Dance");
    }
}
