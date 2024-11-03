using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterbasketballspawner : MonoBehaviour
{
    public GameObject ballobject;
    public Sprite[] ballsprites;
    void Start()
    {
        spawn();
    }

    void spawn(){
        for(int i = 0; i< 12; i++){
            GameObject a = Instantiate(ballobject, transform);
            a.transform.position += new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
            a.GetComponent<SpriteRenderer>().sprite = ballsprites[Random.Range(0, ballsprites.Length)];
        }
    }
}
