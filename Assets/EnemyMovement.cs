using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed = 5f;
    private Camera m_camera;
    private bool onScreen;
    private bool hitLeft = false;
    private bool hitRight = true;
    public float flySpeed = 1f;
    public float flyDist = 2f;
    public float pauseTime = 1f;
    private bool flyingUp = true;

    void Start()
    {
        m_camera = Camera.main;
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(Fly());
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

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("you are die");
        }
    }

// for flying enemies set the regular speed field to 0 otherwise it will activate the regular enemy moving script
    IEnumerator Fly() 
    {
        Vector3 startPos = transform.position;
        Vector3 topPos = startPos + new Vector3(0, flyDist, 0);

        while (true)
        {
            Vector3 target = flyingUp ? topPos : startPos;

            while (Vector3.Distance(transform.position, topPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, flySpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = target;
            yield return new WaitForSeconds(pauseTime);
            flyingUp = !flyingUp;
        }
    }
}
