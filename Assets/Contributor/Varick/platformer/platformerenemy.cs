using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerenemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2;
    int dir = 1;
    public Transform spritetransform;

    public LayerMask layerMask;

    bool died = false;

    void FixedUpdate()
    {
        if(!died){
            rb.velocity = new Vector3(dir * speed, rb.velocity.y, 0);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(dir, 0), 0.625f, layerMask);
            if (hit){
                changedir();
            }

            RaycastHit2D hit1 = Physics2D.Raycast(transform.position + new Vector3(dir * 0.4f, 0 , 0), -Vector2.up, 0.625f);
            if (!hit1 && rb.velocity.y == 0){
                changedir();
            }
        }else{
            transform.Rotate(Vector3.forward * 5);
        }
    }

    void changedir(){
        dir *= -1;
        if(dir == 1){
            spritetransform.rotation = Quaternion.Euler(0, 0, 0);
        }else{
            spritetransform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void die(){
        died = true;
        GetComponent<Collider2D>().enabled = false;
        rb.velocity = new Vector2(Random.Range(-3, 3), 5);
        Destroy(gameObject, 3);
    }
    
}
