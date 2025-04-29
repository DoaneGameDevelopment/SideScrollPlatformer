using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float speed;
    public float verticalSpeed; // i'm not gonna touch it but i don't think this does anything rn
    private float Move;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // jump (still needs bool to stop infinite jump)
        {
            rigidBody.linearVelocityY += 5;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) { // sprint just multiplies current speed by two
            speed = 2; // need to adjust speed as needed i think
            rigidBody.linearVelocityX *= speed; // i don't know if this needs to change to fix it
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) { // basically to check when you're not sprinting
            speed = 1;
            rigidBody.linearVelocityX *= speed;
        }

        Move = Input.GetAxis("Horizontal");
        rigidBody.linearVelocity = new Vector2(Move * speed, rigidBody.linearVelocityY);
        
    }
}