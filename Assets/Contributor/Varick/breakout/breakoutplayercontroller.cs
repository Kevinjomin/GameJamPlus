using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakoutplayercontroller : MonoBehaviour
{
    public float SPEED = 2;
    float movX;
    public Rigidbody2D rb;
    public GameObject blood;

    void Start(){
        if(Random.Range(0, 3) == 0 && MinigameManager.Instance.section > 1){
            blood.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        movX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movX, 0) * SPEED;
        
    }
}
