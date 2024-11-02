using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakebodycontroller : MonoBehaviour
{
    public snakebodycontroller follow;
    public snakeplayermov headcon;
    public Vector3 lastpos;
    public GameObject body;
    public void move()
    {
        lastpos = transform.position;
        if(follow == null){
            transform.position = headcon.lastpos;
        }else{
            transform.position = follow.lastpos;
        }
    }

    public snakebodycontroller addbody(){
        Transform a = Instantiate(body, transform.parent).transform;
        a.position = transform.position  + (follow.transform.position - transform.position);
        snakebodycontroller b = a.gameObject.GetComponent<snakebodycontroller>();
        b.body = body;
        b.follow = this;

        return b;
    }
}
