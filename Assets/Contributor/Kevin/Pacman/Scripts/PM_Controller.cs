using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 5f;

    public enum Direction
    {
        up, down, left, right, none
    }
    public Direction currentDirection = Direction.none;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
        Move();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentDirection = Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentDirection = Direction.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentDirection = Direction.right;
        }

    }

    private void Move()
    {
        Vector2 movement = Vector2.zero;

        switch (currentDirection)
        {
            case Direction.up:
                movement = Vector2.up;
                break;
            case Direction.down:
                movement = Vector2.down;
                break;
            case Direction.left:
                movement = Vector2.left;
                break;
            case Direction.right:
                movement = Vector2.right;
                break;
        }

        rb.velocity = movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PM_EnemyPatrol>())
        {
            MinigameManager.Instance.TriggerGameLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            PM_Manager.Instance.AddScore(1);
            collision.gameObject.SetActive(false);
        }
    }
}
