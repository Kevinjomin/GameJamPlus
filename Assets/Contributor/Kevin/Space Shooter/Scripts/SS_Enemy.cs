using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] Transform shootPosition;

    public SS_BulletPool bulletPool;

    public float moveSpeed;

    public bool canShoot = false;
    public float bulletSpeed = 1f;
    public float shootCooldown = 3f;
    public float currentCooldown;

    public AudioClip deathSFX;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    private void Shoot()
    {
        var bullet = bulletPool.TakeBulletFromPool();
        bullet.InitializeBullet(bulletPool, shootPosition, (rb.velocity.y + bulletSpeed) * -1f);
        currentCooldown = shootCooldown;
    }
    private void CheckCooldown()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void Die()
    {
        SoundManager.Instance.PlaySFXFromMonitor(deathSFX);
        SS_Manager.Instance.AddScore(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<SS_Enemy>()) return;
        Destroy(gameObject);
    }
}
