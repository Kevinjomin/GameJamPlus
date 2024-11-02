using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_EnemyPatrol : MonoBehaviour
{
    Animator animator;

    [SerializeField] List<Transform> waypoints = new List<Transform>();
    public int nextWaypointIndex;
    private Vector3 previousPosition;

    public float moveSpeed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position) < 0.01f)
        {  
            if(nextWaypointIndex >= waypoints.Count - 1)
            {
                nextWaypointIndex = 0;
            }
            else
            {
                nextWaypointIndex++;
            }

            SetAnimation();
        }
    }

    private void SetAnimation()
    {
        Vector3 movementDirection = CalculateDistanceBetweenWaypoints();

        if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
        {
            animator.SetTrigger("MoveHorizontal");
            Flip(movementDirection.x);
        }
        else
        {
            if (movementDirection.y > 0)
            {
                animator.SetTrigger("MoveUp");
            }
            else
            {
                animator.SetTrigger("MoveDown");
            }
        }

        previousPosition = transform.position;
    }

    private void Flip(float x)
    {
        if ((x < 0 && transform.localScale.x > 0) || (x > 0 && transform.localScale.x < 0))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private Vector3 CalculateDistanceBetweenWaypoints()
    {
        if(nextWaypointIndex == 0)
        {
            return waypoints[nextWaypointIndex].position - waypoints[waypoints.Count - 1].position;
        }
        else
        {
            return waypoints[nextWaypointIndex].position - waypoints[nextWaypointIndex - 1].position;
        }
    }

}
