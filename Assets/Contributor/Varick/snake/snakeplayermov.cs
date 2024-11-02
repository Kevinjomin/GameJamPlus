using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeplayermov : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("move", 0.1f, 0.5f);
    }

    // Update is called once per frame
    float movX, movY;
    public Vector3 dir = new Vector3(1, 0, 0), dircheck = new Vector3(1, 0, 0);

    public List<snakebodycontroller> bodyconlist = new List<snakebodycontroller>();

    void FixedUpdate()
    {
        movX = Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");

        if(movX != 0 && dircheck.y != 0){
            dir = new Vector3(movX, 0, 0);
        }
        
        if(movY != 0 && dircheck.x != 0){
            dir = new Vector3(0, movY, 0);
        }
    }

    public Vector3 lastpos;
    void move()
    {
        lastpos = transform.position;
        transform.position += dir * 0.5f;
        dircheck = dir;
        foreach(snakebodycontroller a in bodyconlist){
            a.move();
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "snakefood"){
            addbody();
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        MinigameManager.Instance.TriggerGameLose();
    }

    void addbody(){
        int a = bodyconlist.Count;
        a--;
        snakebodycontroller b = bodyconlist[a].addbody();
        bodyconlist.Add(b);
    }
}
