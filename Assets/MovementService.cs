using UnityEngine;

public class MovementService : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 sideForce = new Vector3(0.0f, 0.0f, 20f);
    public Vector3 forwardForce = new Vector3(100f, 0.0f, 0.0f);
    public Vector3 jumpForce = new Vector3(0.0f, 100f, 0.0f);
    private bool isGtounded = true;


    void Start()
    {
        Debug.Log("Hello world!");
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.detectCollisions =true;
       
    }

    void OnCollisionStay()
    {
        isGtounded = true;
    }


    void FixedUpdate()
    {
        rb.AddForce(forwardForce * Time.deltaTime, ForceMode.Force);

        if (Input.GetKey("a")) {

            rb.AddForce(sideForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(-sideForce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGtounded)
        {
            isGtounded = false;
            Debug.Log("Jump");
            rb.AddForce(jumpForce * Time.deltaTime, ForceMode.VelocityChange);
        }

    }

  
    
}
