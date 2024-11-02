using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class snakeplayermov : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite headsnake, body;
    public GameObject ef, ef1;
    void Start()
    {
        InvokeRepeating("move", 3, 0.5f);
        if(MinigameManager.Instance.section > 1){
            GetComponent<SpriteRenderer>().sprite = headsnake;
            ef.SetActive(true);
            foreach(snakebodycontroller a in bodyconlist){
                a.gameObject.GetComponent<SpriteRenderer>().sprite = body;
            }
        }
    }

    // Update is called once per frame
    float movX, movY;
    public Vector3 dir = new Vector3(1, 0, 0), dircheck = new Vector3(1, 0, 0);

    public List<snakebodycontroller> bodyconlist = new List<snakebodycontroller>();

    public TMP_Text scoretxt;

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
        scoretxt.text = "Score : " + bodyconlist.Count + " / 15";
        if(bodyconlist.Count >= 15){
            MinigameManager.Instance.TriggerGameWin();
        }
        bodyconlist.Add(b);
        if(MinigameManager.Instance.section > 1){
            b.gameObject.GetComponent<SpriteRenderer>().sprite = body;
        }
    }
}
