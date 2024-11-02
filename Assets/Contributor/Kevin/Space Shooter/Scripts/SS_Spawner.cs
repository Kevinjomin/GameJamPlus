using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Spawner : MonoBehaviour
{
    public List<SS_Enemy> enemyPrefabs = new List<SS_Enemy>();
    public float spawnCooldown;
    public float spawnRange; //this is the spawn range vertically

    [SerializeField] private SS_BulletPool bulletPool;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int random = Random.Range(0, enemyPrefabs.Count);
        var enemy = Instantiate(enemyPrefabs[random], SetPosition(), Quaternion.identity, transform);
        enemy.bulletPool = bulletPool;

        yield return new WaitForSeconds(spawnCooldown);

        StartCoroutine(Spawn());
    }

    private Vector3 SetPosition()
    {
        var position = this.transform.position;
        float random = Random.Range(-spawnRange, spawnRange);
        random = Mathf.Round(random);
        position.x = random;

        return position;
    }
}
