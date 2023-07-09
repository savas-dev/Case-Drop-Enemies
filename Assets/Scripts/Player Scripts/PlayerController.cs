/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

// we added character controller to object automaticly
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // we can access this scripts with this instance from all of scripts
    public static PlayerController instance;

    [Header("Elements")]
    [SerializeField] private JoystickController _joystickController;
    private CharacterController characterController;
    private PlayerAnimController _playerAnimController;
    private Vector3 _moveVector;
    

    [Header("Player Settings")]
    [SerializeField] private float _moveSpeed;
    public float forcePower;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        _playerAnimController = GetComponent<PlayerAnimController>();
    }

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        // when game is started, move player codes will be active
        if (GameManager.instance.isGameStart && !GameManager.instance.isGameWin)
        {
            _playerAnimController.PlayRunAnim();
            _moveVector = _joystickController.GetMoveVector() * _moveSpeed * Time.deltaTime / Screen.width;


            // we equal z and y vector and we equal y to 0 for we dont want our player go to up
            _moveVector.z = _moveVector.y;
            _moveVector.y = 0;

            characterController.Move(_moveVector);

            // player face return to move direction
            transform.forward = _moveVector.normalized;
        }
    }

    public void IncreaseForcePower(float forceValue)
    {
        forcePower += forceValue;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // add force to enemy opposite position
            Vector3 dir = collision.transform.position - transform.position;
            dir.Normalize();
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * forcePower, ForceMode.Impulse);

            collision.gameObject.transform.DOMove(new Vector3(dir.x * forcePower, 2.20281f, dir.z * forcePower), .3f);

        }
    }
}
