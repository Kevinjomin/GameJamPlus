using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kongplayermovement : MonoBehaviour
{
    public Rigidbody2D rb;
    float movX,movY;
    public float speed = 2, jumpForce = 5;
    public bool died = false, grounded, instair = false;
    public LayerMask layerMask;
    public Animator anim;

    public Transform spritetransform;

    void FixedUpdate(){
        if(!died){
            movX = Input.GetAxisRaw("Horizontal");

            if(movX > 0){
                spritetransform.rotation = Quaternion.Euler(0,0,0);
            }else if(movX < 0){
                spritetransform.rotation = Quaternion.Euler(0,180,0);
            }

            rb.velocity = new Vector2(movX * speed, rb.velocity.y);

            if((Input.GetButton("Jump") || Input.GetKey("w")) && instair){
                rb.velocity = new Vector2(rb.velocity.x, 2);
            }
            
            if(Input.GetButton("Jump") && grounded){
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }   
        }else{
            rb.velocity = new Vector2(0,0);
        }

        anim.SetInteger("speed", (int)movX);

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
            MinigameManager.Instance.TriggerGameWin();
        }
        if(collision.gameObject.name == "kongstair"){
            Debug.Log("sss");
            instair = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.name == "kongstair"){
            instair = false;
        }
    }

    void die(){
        died = true;
        Debug.Log("fail");
        MinigameManager.Instance.TriggerGameLose();
    }
}
