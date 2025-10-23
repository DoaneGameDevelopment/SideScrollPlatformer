using System;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rigidBody;
    public float speed;
    public float verticalSpeed; // i'm not gonna touch it but i don't think this does anything rn
    private bool isGrounded = true;
    private float Move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody.freezeRotation = true; // no more rotate
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // jump (still needs bool to stop infinite jump)
        {
            rigidBody.linearVelocityY += 5;
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        { // sprint just multiplies current speed by two
            speed = 2; // need to adjust speed as needed i think
            rigidBody.linearVelocityX *= speed; // i don't know if this needs to change to fix it
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        { // basically to check when you're not sprinting
            speed = 1;
            rigidBody.linearVelocityX *= speed;
        }

        Move = Input.GetAxis("Horizontal");
        rigidBody.linearVelocity = new UnityEngine.Vector3(Move * speed, rigidBody.linearVelocityY);
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.transform.localScale += new UnityEngine.Vector3(0f, -1f, 0f);
            player.transform.position += new UnityEngine.Vector3(0f, -0.5f, 0f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            player.transform.localScale += new UnityEngine.Vector3(0f, 1f, 0f);
            player.transform.position += new UnityEngine.Vector3(0f, 0.5f, 0f);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}
