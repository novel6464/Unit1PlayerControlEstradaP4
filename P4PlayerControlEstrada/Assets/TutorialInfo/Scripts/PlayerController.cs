using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 100.0f;
    private float turnspeed = 30.0f;
    private float horizontalInput;
    private float fowardInput;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;


    // Update is called once per frame

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);
        transform.Rotate(Vector3.up, turnspeed * horizontalInput * Time.deltaTime);
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;

        }

    }
}
