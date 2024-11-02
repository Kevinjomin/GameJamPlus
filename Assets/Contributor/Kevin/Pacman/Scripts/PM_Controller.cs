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
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentDirection = Direction.down;
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentDirection = Direction.left;
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentDirection = Direction.right;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PM_EnemyPatrol>())
        {
            MinigameManager.Instance.TriggerGameLose();
        }

        if (collision.gameObject.GetComponent<PM_EnemyChase>())
        {
            MinigameManager.Instance.TriggerGameLose();
        }

        if (collision.gameObject.CompareTag("Point"))
        {
            PM_Manager.Instance.AddScore(1);
            collision.gameObject.SetActive(false);
        }
    }
}
