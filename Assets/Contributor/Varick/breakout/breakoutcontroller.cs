using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakoutcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1;
    public AudioClip audihit, audibreak;

    void Start(){
        Invoke("startwait", 3);
    }

    void startwait(){
        rb.AddForce(new Vector2(Random.Range(-1.5f, 1.5f), -1), ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
        if(rb.velocity.magnitude < speed){
            rb.velocity += rb.velocity * 0.5f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "brickbreakout"){
            SoundManager.Instance.PlaySFXFromMonitor(audibreak);
            Destroy(collision.gameObject);
            return;
        }

        if(collision.gameObject.tag == "breakoutdead"){
            Debug.Log("lose");
            MinigameManager.Instance.TriggerGameLose();
            Destroy(gameObject);
            return;
        }

        SoundManager.Instance.PlaySFXFromMonitor(audihit);
    }
}
