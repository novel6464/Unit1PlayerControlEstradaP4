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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera.enabled = true;
        hoodCamera.enabled = false;
    }
   



    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * fowardInput);
        transform.Rotate(Vector3.up, turnspeed * horizontalInput * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(mainCamera.enabled)
            {
                mainCamera.enabled = false;
                hoodCamera.enabled = true;
            }
            else
            {
                mainCamera.enabled = true;
                hoodCamera.enabled = false;
            }
           
        }

    }
}
