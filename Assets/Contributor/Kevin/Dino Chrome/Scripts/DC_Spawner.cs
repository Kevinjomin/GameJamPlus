using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC_Spawner : MonoBehaviour
{
    [SerializeField] List<DC_Obstacle> obstacles = new List<DC_Obstacle>();

    [SerializeField] float spawnInterval;
    [SerializeField] float speed;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnInterval);

        DC_Obstacle obstacle = obstacles[GetRandomIndex()];
        obstacle.moveSpeed = speed;
        Instantiate(obstacle, transform.position, Quaternion.identity, transform);

        StartCoroutine(Spawn());
    }

    private int GetRandomIndex()
    {
        int random = Random.Range(0, obstacles.Count);
        return random;
    }
}
