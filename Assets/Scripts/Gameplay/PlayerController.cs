using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GroundDetector groundDetector;

    [SerializeField]
    private ParticleSystem movementEffect;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        movementEffect.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundDetector.isGrounded)
        {
            groundDetector.isGrounded = false;
            animator.SetTrigger("onJump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("isSliding");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }

    }

    private void Die()
    {
        GameManager.Instance.ShowGameOverUI();
        animator.SetBool("playerDead", true);
        Time.timeScale = 0;
    }
}
