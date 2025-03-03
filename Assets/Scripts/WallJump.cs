using UnityEngine;

public class WallJump : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 wallJumpVelocity;
    bool jumpInput;
    public static bool IsOnWallBool;
    public bool isOnWall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerJump.defaultGravityScale = rb.gravityScale;
    }

    private void Update()
    {
        jumpInput = Input.GetButtonDown("Jump");
        print(IsOnWallBool);

    }
    private void FixedUpdate()
    {
        if (isOnWall && Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.gravityScale = PlayerJump.defaultGravityScale * 0.2f;
            if (jumpInput) JumpFromWall();
        }
    }
    void OnTriggerEnter2D(Collider2D trigger)

    {
        if (trigger.CompareTag("Ground")) isOnWall = true;
    }
    void OnTriggerExit2D(Collider2D trigger)
    {
        isOnWall = false;
    }

    public void JumpFromWall()
    {
        rb.AddForce(1000 * Time.fixedDeltaTime * Time.fixedDeltaTime * new Vector2(-Input.GetAxisRaw("Horizontal") * wallJumpVelocity.x, wallJumpVelocity.y), ForceMode2D.Impulse);
    }

}
