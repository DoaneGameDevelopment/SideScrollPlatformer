using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public float speed = 0.12f;

    private Vector3 smoothPosition;


    void FixedUpdate() {
        // fixedUpdate basically ties to the physics engine timing, rather than each frame, therefore, frame studders don't lag the camera.
        smoothPosition = Vector3.Lerp(this.transform.position, new Vector3(player.position.x, player.position.y, this.transform.position.z), speed);
        this.transform.position = smoothPosition;
        Vector3 mouse = Input.mousePosition;
    }
}
