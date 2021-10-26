using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 100f;
    protected float verticalDirection = 1;

    public bool IsInvulnerable { get; private set; }

    private bool canMove = true;

    protected Rigidbody rb;
    protected Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if (canMove == true)
        {
            rb.velocity = Vector3.forward * verticalDirection * movementSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }

    public virtual void Die()
    {
        animator.SetTrigger("Death");
        canMove = false;
        Debug.Log(name + " has died!");
    }

    public virtual void Win()
    {
        IsInvulnerable = true;
        Debug.Log(name + " has won!");
    }
}
