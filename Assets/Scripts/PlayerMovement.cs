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
}
