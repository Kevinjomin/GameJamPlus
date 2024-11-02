using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakoutplayercontroller : MonoBehaviour
{
    public float SPEED = 2;
    float movX;
    public Rigidbody2D rb;
    void FixedUpdate()
    {
        movX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movX, 0) * SPEED;
        
    }
}
