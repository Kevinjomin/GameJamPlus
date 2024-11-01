using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_BulletPool : MonoBehaviour
{
    public SS_Bullet bulletPrefab;
    public int poolSize;

    private List<SS_Bullet> bullets = new List<SS_Bullet>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(bulletPrefab, transform);
            bullets.Add(bullet);
            bullet.gameObject.SetActive(false);
        }
    }

    public SS_Bullet TakeBulletFromPool()
    {
        if (bullets.Count > 0)
        {
            var bullet = bullets[0];
            bullets.Remove(bullet);
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        return null;
    }

    public void ReturnBulletToPool(SS_Bullet returnedBullet)
    {
        if (bullets.Count < poolSize)
        {
            bullets.Add(returnedBullet);
            returnedBullet.gameObject.SetActive(false);
        }
    }
}
