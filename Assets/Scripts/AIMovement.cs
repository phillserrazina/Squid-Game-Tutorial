using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : CharacterMovement
{
    private Robot robot;

    private void OnEnable() 
    {
        if (robot == null)
            robot = FindObjectOfType<Robot>();

        robot.OnStartCounting += OnStartCounting;
        robot.OnStopCounting += OnStopCounting;
    }

    private void Update() 
    {


        animator.SetFloat("Speed", rb.velocity.normalized.magnitude);    
    }

    private void OnStartCounting()
    {
        verticalDirection = 1;
    }

    private void OnStopCounting()
    {
        verticalDirection = 0;
    }
}
