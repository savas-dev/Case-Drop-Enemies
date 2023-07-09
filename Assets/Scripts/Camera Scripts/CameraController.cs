/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public GameObject player;
    public Vector3 offset;
    public bool isFollowStart;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void LateUpdate()
    {
        // if game start, set cam position smoothly
        if (isFollowStart && !GameManager.instance.isGameOver)
        {
            FollowPlayer();
        }

        // if gameover, set cam to gameover position
        if (GameManager.instance.isGameOver)
        {
            GameOverCam();
        }
    }

    public void FollowPlayer()
    {
        // lerp funcion for smooth following
        transform.position = Vector3.Lerp(transform.position, player.transform.position - offset, 2f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(48f, 5f, 0f);
    }

    public void GameOverCam()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(-3.4f, 22.99f, -27.77f), 2f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(48f, 5f, 0f);
    }


}
