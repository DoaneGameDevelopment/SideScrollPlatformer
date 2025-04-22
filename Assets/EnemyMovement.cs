using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
            m_player = GetComponent<Player>();
            m_camera = FindObjectOfType<Camera>();
        
        public void CheckVisibility()
        {
            //Check Visibility

            screenPos = m_camera.WorldToScreenPoint(transform.position);
            onScreen = screenPos.x > 0f && screenPos.x < Screen.width && screenPos.y > 0f && screenPos.y < Screen.height;

            if (onScreen && m_player.isVisible)
            {
        




            }
            
        }
     }
}