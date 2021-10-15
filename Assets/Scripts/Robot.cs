using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RobotStates { Counting, Inspecting }

public class Robot : MonoBehaviour
{
    [SerializeField] private float startInspectionTime = 2f;
    [SerializeField] private AudioSource jingleSource;

    private float currentInspectionTime;
    private RobotStates currentState = RobotStates.Counting;

    public delegate void OnStartCountingDelegate();
    public OnStartCountingDelegate OnStartCounting;

    public delegate void OnStopCountingDelegate();
    public OnStopCountingDelegate OnStopCounting;

    private Animator animator;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();

        currentInspectionTime = startInspectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            StateMachine();
    }

    private void StateMachine()
    {
        switch (currentState)
        {
            case RobotStates.Counting:
                Count();
                break;
            case RobotStates.Inspecting:
                Inspect();
                break;
            default:
                break;
        }
    }

    private void Count()
    {
        if (!jingleSource.isPlaying)
        {
            animator.SetTrigger("Look");
            currentState = RobotStates.Inspecting;
            OnStopCounting?.Invoke();
        }
    }

    private void Inspect()
    {
        if (currentInspectionTime > 0)
        {
            currentInspectionTime -= Time.deltaTime;

            if (player.IsMoving())
            {
                Destroy(player.gameObject);
            }
        }
        else
        {
            currentInspectionTime = startInspectionTime;
            animator.SetTrigger("Look");

            jingleSource.Play();
            currentState = RobotStates.Counting;
            OnStartCounting?.Invoke();
        }
    }
}
