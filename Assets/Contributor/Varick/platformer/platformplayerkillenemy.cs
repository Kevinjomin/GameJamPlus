using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformplayerkillenemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "enemy"){
            platformerenemy a = collision.gameObject.GetComponent<platformerenemy>();
            if(a!=null){
                a.die();
            }
        }
    }
}
