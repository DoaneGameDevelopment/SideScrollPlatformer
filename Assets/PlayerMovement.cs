using System;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
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
}
