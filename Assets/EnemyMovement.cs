using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;
    private Camera m_camera;
    private bool onScreen;
    private bool hitLeft = false;
    private bool hitRight = true;

    void Start()
    {
        m_camera = Camera.main;
        rigidBody.bodyType = RigidbodyType2D.Dynamic;

    }

    void Update()
    {
        Vector3 screenPos = m_camera.WorldToScreenPoint(transform.position);
        onScreen = true;

        if (onScreen)
        {
            if (hitRight)
            {
                rigidBody.linearVelocity = new Vector2(-speed, rigidBody.linearVelocity.y);
            }
            else if (hitLeft)
            {
                rigidBody.linearVelocity = new Vector2(speed, rigidBody.linearVelocity.y);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Flip direction on collision
            if (hitRight)
            {
                hitRight = false;
                hitLeft = true;
                Debug.Log("cool");
            }
            else
            {
                hitRight = true;
                hitLeft = false;
            }
        }
    }
}
