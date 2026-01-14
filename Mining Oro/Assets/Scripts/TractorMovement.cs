using UnityEngine;

public class TractorMovement : MonoBehaviour
{
    public float maxSpeed = 8f;
    public float acceleration = 6f;
    public float brakeForce = 8f;
    public float turnStrength = 70f;

    private float currentSpeed = 0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");   // W / S
        float turnInput = Input.GetAxis("Horizontal");    // A / D

        // --- ACCELERATION LOGIC ---
        if (Mathf.Abs(forwardInput) > 0.1f)
        {
            currentSpeed += forwardInput * acceleration * Time.fixedDeltaTime;
        }
        else
        {
            // Natural slowing when no key pressed
            currentSpeed = Mathf.Lerp(currentSpeed, 0, brakeForce * Time.fixedDeltaTime);
        }

        // Clamp speed
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed / 2, maxSpeed);

        // --- MOVE TRACTOR ---
        Vector3 move = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);

        // --- STEERING (only if moving) ---
        if (Mathf.Abs(currentSpeed) > 0.5f)
        {
            float turn = turnInput * turnStrength * Time.fixedDeltaTime;

            // Reverse steering when backing up (realistic)
            if (currentSpeed < 0)
                turn *= -1;

            Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * rotation);
        }
    }
}
