using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float rotationSpeed = 700f; // Rotation speed

    void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Move the player forward/backward
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        if (moveDirection.magnitude > 0f)
        {
            // Move the player
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // Rotate the player to face movement direction
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}