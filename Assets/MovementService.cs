using UnityEngine;

public class MovementService : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 sideForce = new Vector3(0.0f, 0.0f, 0.35f);
    private Vector3 forwardForce = new Vector3(1000f, 0.0f, 0.0f);
    private Vector3 jumpForce = new Vector3(0.0f, 500f, 0.0f);

    private bool isGrounded = true;


    void Start()
    {
        Debug.Log("Hello world!");
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.detectCollisions =true;
        rb.isKinematic = false;
       
    }

    private void Update()
    {
        if (Input.GetKey("a"))
        {

            rb.AddForce(sideForce, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(-sideForce, ForceMode.VelocityChange); 
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(forwardForce * Time.deltaTime, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
