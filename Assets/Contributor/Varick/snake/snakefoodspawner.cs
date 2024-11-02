using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakefoodspawner : MonoBehaviour
{
    public GameObject food;
    void FixedUpdate()
    {
        if(transform.childCount <= 0){
            Instantiate(food, transform).transform.position = new Vector3(Random.Range(-10, 10) * 0.5f, Random.Range(-10, 10) * 0.5f, 0);

        }
    }
}
