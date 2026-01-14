using UnityEngine;
using UnityEngine.InputSystem;

public class TractorController : MonoBehaviour
{
    public float maxSpeed = 8f;
    public float acceleration = 6f;
    public float brakeForce = 8f;
    public float turnStrength = 70f;

    private float currentSpeed = 0f;
    private Rigidbody rb;

    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // This is called automatically by Player Input
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        float forwardInput = moveInput.y;
        float turnInput = moveInput.x;

        // Acceleration
        if (Mathf.Abs(forwardInput) > 0.1f)
        {
            currentSpeed += forwardInput * acceleration * Time.fixedDeltaTime;
        }
        else
        {
            // Natural slowing
            currentSpeed = Mathf.Lerp(currentSpeed, 0, brakeForce * Time.fixedDeltaTime);
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed / 2, maxSpeed);

        // Move tractor
        Vector3 move = transform.forward * currentSpeed;
        rb.velocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
        // Steering only when moving
        if (Mathf.Abs(currentSpeed) > 0.5f)
        {
            float turn = turnInput * turnStrength * Time.fixedDeltaTime;

            // Realistic reverse steering
            if (currentSpeed < 0)
                turn *= -1;

            Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * rotation);
        }
    }
}
