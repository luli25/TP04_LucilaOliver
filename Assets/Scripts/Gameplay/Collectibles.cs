using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private Rigidbody2D rb;

    private float moveSpeed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.left * moveSpeed;
    }

}
