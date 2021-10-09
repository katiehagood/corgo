using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int speed;
    private Rigidbody2D rigidBody;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        screenBounds = getScreenBounds();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);

        // Get rid of obstacle when it goes off screen
        if (transform.position.x < -screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }

    // Gets the screen boundry
    public Vector3 getScreenBounds()
    {
        float x = Screen.width;
        float y = Screen.height;
        float z = Camera.main.transform.position.z;

        return Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));
    }

    // Sets the speed at which this obstacle moves to the left
    public void setSpeed(int givenSpeed)
    {
        speed = givenSpeed;
    }
}
