/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    [Header("Joystick Elements")]
    [SerializeField] private RectTransform _joystickOutline;
    [SerializeField] private RectTransform _joystickInline;

    [Header("Joystick Settings")]
    [Range(200, 600)]
    [SerializeField] private float _moveFactor;
    [SerializeField] private Vector3 _move;
    [SerializeField] private bool _canControl;
    [SerializeField] private Vector3 _clickedPos;
    private Vector3 _oldDirection;

    private void Start()
    {
        HideJoystick();
    }

    private void Update()
    {
        // if canControl is true, we can control joystick. if is not, we can't control
        if (_canControl)
        {
            JoystickControl();
        }
    }

    // When click on joystick zone
    public void ClickedOnJoystickZone()
    {
        // we create clickedPos vector and equals to where we will touch.
        _clickedPos = Input.mousePosition;
        // we equals joystick outline pos to clicked pos
        _joystickOutline.position = _clickedPos;

        // if do u want show joystick, you can use this code
        ShowJoystick();
    }

    // show joystick
    public void ShowJoystick()
    {
        _joystickOutline.gameObject.SetActive(true);
        _canControl = true;
    }

    // hide joystick
    public void HideJoystick()
    {
        _joystickOutline.gameObject.SetActive(false);
        _canControl = true;

        _move = Vector3.zero;
    }

    public void JoystickControl()
    {
        // create currentPos and equals to where we touch
        Vector3 currentPos = Input.mousePosition;
        // create direction vector and equal to minus of current and clickedpos
        Vector3 direction = currentPos - _clickedPos;

        // fix player move when mouse up and when direction magnitude is 0
        if(direction.magnitude > 0)
        {
            _oldDirection = direction;
        }
        if(direction.magnitude == 0)
        {
            direction = _oldDirection;
        }

        // if you want smooth move with joystick use this code
        // float moveMagnitude = direction.magnitude * _moveFactor / Screen.width;

        // if you want move player same speed all times use this code
        float moveMagnitude = direction.magnitude * _moveFactor;
        moveMagnitude = Mathf.Min(moveMagnitude, _joystickOutline.rect.width / 1.4f);

        _move = direction.normalized * moveMagnitude;

        Vector3 targetPos = _clickedPos + _move;

        _joystickInline.position = targetPos;

        // if we show joystick and when touch up we can hide joystick this code:
        if (Input.GetMouseButtonUp(0))
        {
            HideJoystick();
        }
    }

    public Vector3 GetMoveVector()
    {
        return _move;
    }
}
