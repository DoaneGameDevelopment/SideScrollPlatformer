using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float speed;
    public float verticalSpeed;
    private float Move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.linearVelocityY += 5;
        }
        Move = Input.GetAxis("Horizontal");
        rigidBody.linearVelocity = new Vector2(Move * speed, rigidBody.linearVelocityY);
        
    }
}
