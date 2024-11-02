using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_EnemyPatrol : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints = new List<Transform>();
    public int nextWaypointIndex;

    public float moveSpeed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(Vector3.Distance(transform.position, waypoints[nextWaypointIndex].position) < 0.01f)
        {  
            if(nextWaypointIndex >= waypoints.Count - 1)
            {
                nextWaypointIndex = 0;
            }
            else
            {
                nextWaypointIndex++;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypointIndex].position, moveSpeed * Time.deltaTime);
    }
}
