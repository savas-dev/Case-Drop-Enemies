/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [Header("Animator Settings")]
    [SerializeField] private Animator _playerAnimator;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    public void ManageAnims(Vector3 moveVector)
    {
        // if we want player doesnt move on start and player first move start with joystick,
        // we can use this code

        //if(moveVector.magnitude > 0)
        //{
        //    PlayRunAnim();
        //}
        //else
        //{
        //    PlayIdleAnim();
        //}
    }

    public void PlayRunAnim()
    {
        _playerAnimator.Play("Run");
    }

    public void PlayIdleAnim()
    {
        _playerAnimator.Play("Idle");
    }

    public void PlayDieAnim()
    {
        _playerAnimator.Play("Die");
    }
}
