using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPipe : MonoBehaviour
{
    [SerializeField] private float moveLeft = 0.7f;

    void Update()
    {
        transform.position += Vector3.left * moveLeft * Time.deltaTime;
    }
}
