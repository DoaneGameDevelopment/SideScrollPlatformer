using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public float speed;
    public float baseSpeed;
    public float speedMultiplier;
    public float jumpHeight;
    private float MoveH;
    private float MoveV;
    private Vector3 movement;
    public bool inSprint = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* initiallize varaibles, but also change stuff so that you don't change it directly like 
        rigidbody.linearVelocityY = new Vector2(blah blah blah)
        */
        rigidBody = GetComponent<Rigidbody2D>();
        jumpHeight = rigidBody.linearVelocityY;
        speed = rigidBody.linearVelocityX;
        baseSpeed = 1; // just values to use currently for now i guess
        speedMultiplier = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) //check if button is pressed
        {
            if (!inSprint) { // this is supposed to be a fail safe so that you don't spam it or smthg i think
                speed = speedMultiplier * baseSpeed;
                inSprint = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) { // go back to base speed once you stop pressing
            speed = baseSpeed;
            inSprint = false;
        }

         if (Input.GetKeyDown(KeyCode.Space)) //i changed some of the jump stuff so that you don't interact with it directly (just because of Mark's class)
        {
            jumpHeight += 5;
        }

        MoveH = Input.GetAxis("Horizontal");
        MoveV = Input.GetAxis("Vertical");
        movement = new Vector2(MoveH, MoveV); // i don't actually know what this does so i think it is to update movement

    }
}
