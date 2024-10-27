using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Sprite[] upSprites;
    public Sprite[] downSprites;
    public Sprite[] leftRightSprites;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AnimatedSprite animatedSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        animatedSprite = GetComponentInChildren<AnimatedSprite>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var horizontal = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) ? -1 : (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ? 1 : 0;
        var vertical = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) ? -1 : (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) ? 1 : 0;
        var move = new Vector2(horizontal, vertical);
        if (move.magnitude > 1)
        {
            move.Normalize();
        }

        FlipSprite(move.x);
        UpdateSprite(move.x, move.y);

        rb.velocity = move * moveSpeed;
    }

    private void FlipSprite(float horizontal)
    {
        if (horizontal < 0)
        {
            sr.flipX = true;
        }
        else if (horizontal > 0)
        {
            sr.flipX = false;
        }
    }

    private void UpdateSprite(float horizontal, float vertical)
    {
        // Up
        if (vertical > 0)
        {
            animatedSprite.SetFrames(upSprites);
        }
        // Down
        else if (vertical < 0)
        {
            animatedSprite.SetFrames(downSprites);
        }
        // Left or Right
        else if (horizontal != 0)
        {
            animatedSprite.SetFrames(leftRightSprites);
        }
    }
}
