using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private SS_BulletPool pool;

    public void InitializeBullet(SS_BulletPool _pool, Transform _transform, float _bulletSpeed)
    {
        pool = _pool;
        transform.position = _transform.position;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, _bulletSpeed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SS_Enemy>())
        {
            collision.GetComponent<SS_Enemy>().Die();
        }
        pool.ReturnBulletToPool(this);
    }
}
