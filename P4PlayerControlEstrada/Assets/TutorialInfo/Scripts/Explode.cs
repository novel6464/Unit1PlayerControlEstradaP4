using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializerField] private float delay = 1.0f;
    [SerializerField] private float radius = 5.0f;
    [SerializerField] private float force = 2700.0f;
    [SerializerField] private bool explodeOnCollision = false;
    [SerializerField] private GameObject effectsPrefab;
    [SerializerField] private float effectDisplayTime = 3.0f;


    private float delaytimer;

    private void Awake()
    {
        delaytimer = 0.0f;
    }
    private void Update ()
    {
        delaytimer += Time.deltaTime;
        if (delaytimer >= delay && !explodeOnCollision) {
            DoExplosion();
            Destroy(gameObject);
        }
            


    }

    private void DoExplosion()
    {
        HandleEffects();
        HandleDestruction();
    }
    private void HandleEffects()
    {
        if (effectsPrefab != null) {
            GameObject effect = Instantiate(effectsPrefab, transform.position, Quaternion.identity);
            Destroy(effect, effectDisplayTime);
        }
    }

    private void HandleDestruction()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rigidbody != null) {
                rigidboody.AddExplosionForce(force, transform.position, radius);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
