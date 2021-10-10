using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private readonly int jumpForce = 400;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Text livesText;

    private Rigidbody2D rigidBody;
    private bool jumpPressed;
    private float horizontalInput;
    private bool grounded;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        jumpPressed = false;
        lives = 3;
        livesText.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            jumpPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, playerMask))
        {
            grounded = true;
        } else
        {
            grounded = false;
        }

        if (jumpPressed && grounded)
        {
            rigidBody.AddForce(Vector2.up * jumpForce);
            jumpPressed = false;
        }
        rigidBody.velocity = new Vector2(horizontalInput, rigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            lives--;
            livesText.text = lives.ToString();
            Debug.Log("Number of lives left : " + lives);
        }

    }
}
