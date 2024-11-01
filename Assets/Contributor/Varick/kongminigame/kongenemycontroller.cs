using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kongenemycontroller : MonoBehaviour
{
    public GameObject barrel;
    public Animator anim;
    void Start(){
        int a = Random.Range(0, 4);
        if(a == 0){
            anim.Play("kong1");
        }else{
            anim.Play("kong");
        }
        InvokeRepeating("spawnbarrel", 0.1f, 3f);
    }
    void spawnbarrel(){
        Instantiate(barrel, transform.position + new Vector3(2, 0 ,0), Quaternion.Euler(0,0,30));
    }
}
