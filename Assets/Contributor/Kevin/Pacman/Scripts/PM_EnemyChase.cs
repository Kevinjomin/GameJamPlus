using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PM_EnemyChase : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;

    Animator animator;

    private Vector2 previousPosition;

    [SerializeField] bool canMoveThroughWall;
    float moveSpeed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        animator = GetComponent<Animator>();

        moveSpeed = agent.speed / 2f;

        if (canMoveThroughWall)
        {
            agent.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
        SetAnimation();
    }

    private void Move()
    {
        if (canMoveThroughWall)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    private void SetAnimation()
    {
        Vector2 currentPosition = transform.position;
        Vector2 movementDirection = (currentPosition - previousPosition).normalized;

        // Set animator parameters based on which direction is more dominant
        if(Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            animator.SetFloat("MoveHorizontal", movementDirection.x);
            animator.SetFloat("MoveVertical", 0f);
        }
        else
        {
            animator.SetFloat("MoveHorizontal", 0f);
            animator.SetFloat("MoveVertical", movementDirection.y);
        }

        previousPosition = currentPosition;
    }
}
