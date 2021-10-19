using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private void Update() 
    {
        verticalDirection = Input.GetAxis("Vertical");
        verticalDirection = Mathf.Clamp(verticalDirection, 0, 1);

        animator.SetFloat("Speed", verticalDirection);
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("Trigger death menu");
    }

    public override void Win()
    {
        base.Win();
        Debug.Log("Trigger win menu");
    }
}
