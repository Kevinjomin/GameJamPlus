using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform shootPosition;
    [SerializeField] SS_BulletPool bulletPool;

    public float moveSpeed = 5f;

    public float bulletSpeed = 1f;
    public float shootCooldown = 0.5f;
    public float currentCooldown;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentCooldown = shootCooldown;
    }

    private void Update()
    {
        CheckInput();
        CheckCooldown();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void Shoot()
    {
        if (currentCooldown > 0f) return;

        var bullet = bulletPool.TakeBulletFromPool();
        bullet.InitializeBullet(bulletPool, shootPosition, bulletSpeed);
        currentCooldown = shootCooldown;
    }
    private void CheckCooldown()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SS_Enemy>())
        {
            MinigameManager.Instance.TriggerGameLose();
        }
    }
}
