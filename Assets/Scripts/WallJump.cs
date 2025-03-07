using UnityEngine;

public class WallJump : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 wallJumpVelocity;
    bool jumpInput;
    public float wallGravityPercent;
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
        IsOnWallBool = isOnWall;
    }
    private void FixedUpdate()
    {
        if (isOnWall && Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.gravityScale = PlayerJump.defaultGravityScale * wallGravityPercent / 100;
            if (jumpInput) JumpFromWall();
        }
    }
    void OnTriggerEnter2D(Collider2D trigger)

    {
        if (trigger.CompareTag("Ground")) isOnWall = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnWall = false;

    }

    public void JumpFromWall()
    {
        rb.AddForce(100 * Time.fixedDeltaTime * new Vector2(-Input.GetAxisRaw("Horizontal") * wallJumpVelocity.x, wallJumpVelocity.y), ForceMode2D.Impulse);
    }

}
