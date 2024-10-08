using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of background movement
    private float width; // Width of the background

    void Start()
    {
        // Get the width of the background sprite
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the background to the left
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Check if the background has moved out of view
        if (transform.position.x < -width)
        {
            // Reset the position to the right side of the other background
            transform.position += new Vector3(width * 2, 0, 0);
        }
    }
}
