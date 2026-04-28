using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy1;
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
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Enemy"))
        {
            // Flip direction on collision
            if (collision.transform.position.x <= enemy1.transform.position.x - 1.33333)
            {
                hitRight = false;
                hitLeft = true;
                Debug.Log("cool");
            }
            if(collision.transform.position.x >= enemy1.transform.position.x + 0.75)
            {
                hitRight = true;
                hitLeft = false;
                Debug.Log("turning back");
            }
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("you are die");
            SceneManager.LoadScene(2);
        }
    }
}
