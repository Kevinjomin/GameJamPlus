using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdJumper : MonoBehaviour
{
    private float rotationSpeed = 10f;
    [SerializeField] private float jumpForce = 4f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Pipes")
        {
            rb2d.freezeRotation = true;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}
