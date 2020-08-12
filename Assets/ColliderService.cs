using UnityEngine;

public class ColliderService : MonoBehaviour
{

    MovementService ms;
    Rigidbody rb;

    void Start()
    {
        ms = GetComponent<MovementService>();
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            rb.freezeRotation = false;
            ms.enabled = false;
        }
    }
}
