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
    private List<Collectibles> collectibles;

    private Rigidbody2D rb;

    private const int lives = 3;

    private int remainingLives;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingLives = lives;

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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    foreach(Collectibles collectible in collectibles)
    //    {
    //        if(collision.CompareTag("Life"))
    //        {
    //            if(remainingLives < lives)
    //            {
    //                do
    //                {
    //                    remainingLives++;

    //                } while (remainingLives < lives);

    //            }
    //           Destroy(collision.gameObject);


    //        } else if(collision.CompareTag("Poison"))
    //        {
    //            animator.Play("Dead", 0);
    //            Destroy(collision.gameObject);

    //        }
    //    }
    //}

    private void Die()
    {
        animator.SetBool("playerDead", false);
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }
}
