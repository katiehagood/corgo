using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 currentForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x;
        float y = 0;

        if (Input.GetButtonDown("Jump")) {
            y = 300;
        }

        x = Input.GetAxis("Horizontal");

        rigidBody.AddForce(new Vector2(x, y));
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(currentForce);
    }
}
