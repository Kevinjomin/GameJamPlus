using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerplayermov : MonoBehaviour
{
    float movX;
    public Rigidbody2D rb;
    public LayerMask layerMask;
    public float speed = 3, jumpforce = 5;

    public Animator anim;

    public Transform spritetransform;

    public Sprite flagsprite;

    public AudioClip audijump;

    void FixedUpdate()
    {
        movX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(movX * speed, rb.velocity.y,0);

        anim.SetInteger("speed", (int)movX);

        if(Input.GetButton("Jump")){
            jump();
        }

        if(movX > 0){
            spritetransform.rotation = Quaternion.Euler(0,0,0);
        }else if(movX < 0){
            spritetransform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    void jump(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, layerMask);
        if (hit)
        {
            SoundManager.Instance.PlaySFXFromMonitor(audijump);
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "platformerfinishline"){
            Debug.Log("win");
            StartCoroutine(waitwin(collision.gameObject));
        }

        if(collision.gameObject.name == "coin"){
            Destroy(collision.gameObject);
        }
    }

    IEnumerator waitwin(GameObject a){
        Transform childtrans = a.transform.GetChild(0);
        for(int i = 0; i<30; i++){
            childtrans.position += new Vector3(0,-0.1f,0);
            yield return new WaitForSeconds(0.02f);
        }
        //childtrans.gameObject.GetComponent<SpriteRenderer>().sprite = flagsprite;
        //yield return new WaitForSeconds(0.2f);
        // for(int i = 0; i<30; i++){
        //     childtrans.position += new Vector3(0,0.1f,0);
        //     yield return new WaitForSeconds(0.02f);
        // }
        yield return new WaitForSeconds(0.2f);
        MinigameManager.Instance.TriggerGameWin();
    }

    void OnCollisonEnter2D(Collision2D collision){
        if(collision.gameObject.name == "enemy"){
            die();
        }

        if(collision.gameObject.name == "deathzone"){
            die();
        }
    }

    void die(){
        Debug.Log("lose");
        MinigameManager.Instance.TriggerGameLose();
    }
}
