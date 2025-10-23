using UnityEngine;
using System.Collections;

public class Move_Plat : MonoBehaviour
{
    public float moveDistance = 2f;  // how far up to move
    public float speed = 2f;         // movement speed
    public float pauseTime = 70f;     // how long to pause at top/bottom

    private Vector3 startPos;
    private Vector3 topPos;
    private bool movingUp = true;

    void Start()
    {
        startPos = transform.position;
        topPos = startPos + new Vector3(0, moveDistance, 0);
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            Vector3 target = movingUp ? topPos : startPos;

            // Move until close to the target
            while (Vector3.Distance(transform.position, target) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }

            // Snap to target and pause
            transform.position = target;
            yield return new WaitForSeconds(pauseTime);

            // Reverse direction
            movingUp = !movingUp;
        }
    }
}
