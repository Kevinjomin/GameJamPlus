using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DC_Controller : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float initialJumpStrength = 10f;
    [SerializeField] private float holdJumpStrength = 5f;
    [SerializeField] private float holdJumpDuration = 0.2f;

    private bool isJumping = false;
    private float jumpHoldTime = 0f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;

    public LayerMask groundLayerMask;
    public AudioClip dinojump;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            SoundManager.Instance.PlaySFXFromMonitor(dinojump);
            Jump();
            isJumping = true;
            jumpHoldTime = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping && jumpHoldTime < holdJumpDuration)
        {
            rb.AddForce(holdJumpStrength * Vector2.up, ForceMode2D.Force);
            jumpHoldTime += Time.fixedDeltaTime;
        }
    }

    private void Jump()
    {
        rb.AddForce(initialJumpStrength * Vector2.up, ForceMode2D.Impulse);
    }

    public bool CheckGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayerMask);
        foreach (Collider2D collider in colliders)
        {
            return true;
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DC_Obstacle>())
        {
            MinigameManager.Instance.TriggerGameLose();
        }
    }
}
