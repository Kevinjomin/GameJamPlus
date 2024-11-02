using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float heightRange = 0.8f;
    [SerializeField] private GameObject pipes;
    private float timer;
    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer = timer + Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject pipe = Instantiate(pipes, spawnPosition, Quaternion.identity, transform);

        Destroy(pipe, 8f);
    }
}
