using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kongplayermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    float movX,movY;
    public float speed = 2, jumpForce = 5;
    bool died = false, grounded;
    public LayerMask layerMask;
    public Animator anim;

    void FixedUpdate(){
        if(!died){
            movX = Input.GetAxisRaw("Horizontal");
            movY = Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector2(movX * speed, rb.velocity.y);
        }else{
            rb.velocity = new Vector2(0,0);
        }

        anim.SetInteger("speed", (int)movX);

        if(Input.GetButton("Jump") && grounded){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.5f, layerMask);

        if (hit){
            grounded = true;
        }else{
            grounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "kongbarrel"){
            die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.name == "finishline"){
            Debug.Log("win");
        }
    }

    void die(){
        died = true;
        Debug.Log("fail");
    }
}
