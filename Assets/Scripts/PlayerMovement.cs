using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float xMovement;
    public float speed = 100f;
    public float maxSpeed = 60f;
    public bool playerFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        InputControl();
    }
    private void FixedUpdate()
    {
        MoveCommand();
    }

    public void InputControl()
    {
        xMovement = Input.GetAxisRaw("Horizontal");
        if (xMovement < 0)
        {
            playerFacingRight = false;
        }
        if (xMovement > 0)
        {
            playerFacingRight = true;
        }
    }
    void MoveCommand()
    {
        if (xMovement == 0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        Vector2 movement = new Vector2(xMovement, 0);

        rb.AddForce(1000 * speed * Time.fixedDeltaTime * movement);

        if (rb.linearVelocity.x > maxSpeed)
        {
            rb.linearVelocity = new Vector2(maxSpeed, rb.linearVelocity.y);
        }
        if (rb.linearVelocity.x < -maxSpeed)
        {
            rb.linearVelocity = new Vector2(-maxSpeed, rb.linearVelocity.y);
        }
    }
}