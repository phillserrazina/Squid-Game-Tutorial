using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private void Update() 
    {
        verticalDirection = Input.GetAxis("Vertical");
        verticalDirection = Mathf.Clamp(verticalDirection, 0, 1);

        sprintValue = Input.GetAxis("Sprint");

        animator.SetFloat("Speed", verticalDirection + sprintValue);
    }

    public override void Die()
    {
        base.Die();
        UIManager.Instance.TriggerLoseMenu();
    }

    public override void Win()
    {
        base.Win();
        UIManager.Instance.TriggerWinMenu();
    }
}
