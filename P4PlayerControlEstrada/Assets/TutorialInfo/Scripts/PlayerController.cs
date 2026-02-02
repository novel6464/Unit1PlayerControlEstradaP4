using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private float speed = 1.0f;
    private float turnspeed = 1.0f;
    private float horizontalInput;
    private float fowardInput;
    

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);
        transform.Rotate(Vector3.up, turnspeed * horizontalInput * Time.deltaTime);
        
    }
}
