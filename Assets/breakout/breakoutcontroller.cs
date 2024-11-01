using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakoutcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1;

    void Start(){
        rb.AddForce(new Vector2(Random.Range(-3, 3), -3), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
        if(rb.velocity.magnitude < speed){
            rb.velocity += rb.velocity;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "brickbreakout"){
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "breakoutdead"){
            Debug.Log("lose");
            Destroy(gameObject);
        }
    }
}
