/*
 This script created by Savaş SARI for No Surrender Studio.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    public static DragAndMove instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private Animator dragAnimator;

    private void Start()
    {
        dragAnimator = GetComponent<Animator>();
    }


    public void StartAnim()
    {
        // start anim and destroy object
        dragAnimator.Play("Drag");
        Destroy(this.gameObject, 3f);
    }
}
