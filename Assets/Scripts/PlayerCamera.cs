using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public float speed = 0.12f;

    private Vector3 smoothPosition;
    private float limited_lower_y;
    private float limited_lower_x;

    public float lower_y_limit = -3f;
    public float lower_x_limit = .5f;


    void FixedUpdate() {

        limited_lower_y = Mathf.Max(lower_y_limit, player.position.y);
        limited_lower_x = Mathf.Max(lower_x_limit, player.position.x);
        // fixedUpdate basically ties to the physics engine timing, rather than each frame, therefore, frame studders don't lag the camera.
        smoothPosition = Vector3.Lerp(this.transform.position, new Vector3(limited_lower_x, limited_lower_y, this.transform.position.z), speed);
        this.transform.position = smoothPosition;
        // Vector3 mouse = Input.mousePosition;
    }
}
