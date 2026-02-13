using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 1f;

    public float turnSpeed = 1.0f;
    public float verticalInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public float tiltAngle = 90 .0f; // Maximum tilt angle (degrees)
    public float smooth = 2.0f; // Speed of the tilting/recentering

    void Update()
    {
        // Get the horizontal input axis (e.g., A/D keys, left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the target Z rotation (tilt)
        // Multiplying by -1 makes pressing 'right' tilt right (negative Z rotation) and 'left' tilt left (positive Z rotation)
        float targetTiltZ = horizontalInput * -tiltAngle;

        // Get the current Euler angles
        Vector3 currentEulerAngles = transform.localEulerAngles;

        // Create a target Quaternion rotation using the desired Z tilt and current X and Y rotations
        Quaternion targetRotation = Quaternion.Euler(currentEulerAngles.x, currentEulerAngles.y, targetTiltZ);

        // Smoothly interpolate towards the target rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = transform.forward * speed;

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left, turnSpeed * verticalInput * Time.deltaTime);
    }
}
