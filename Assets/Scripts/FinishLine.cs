using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        CharacterMovement character = other.GetComponent<CharacterMovement>();

        if (character != null)
        {
            character.Win();
        }
    }
}
