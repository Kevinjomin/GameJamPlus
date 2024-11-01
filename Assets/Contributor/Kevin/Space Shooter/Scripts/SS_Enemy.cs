using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Enemy : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    public void Die()
    {
        SS_Manager.Instance.AddScore(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
