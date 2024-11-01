using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kongenemycontroller : MonoBehaviour
{
    public GameObject barrel;
    void Start(){
        InvokeRepeating("spawnbarrel", 0.1f, 3f);
    }
    void spawnbarrel(){
        Instantiate(barrel, transform.position + new Vector3(2, 0 ,0), Quaternion.Euler(0,0,30));
    }
}
