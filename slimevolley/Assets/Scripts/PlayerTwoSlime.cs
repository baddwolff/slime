using UnityEngine;
using System.Collections;

public class PlayerTwoSlime : MonoBehaviour
{
    public static PlayerTwoSlime S;

    public float forceSpeed;
    public float topSpeed;
    public Vector2 Speed;
    public Vector2 JumpForce;
    public bool isGrounded;
    Rigidbody2D body;

    void Awake()
    {
        S = this;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y <= -3.5f)
            isGrounded = true;

        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.AddForce(new Vector2(0, forceSpeed), ForceMode2D.Impulse);
            isGrounded = false;
        }

        float h = Input.GetAxis("Horizontal2");
        body.AddForce((Vector2.right * 500.0f) * h);

        if (body.velocity.x > 0.0f || body.velocity.x < 0.0f)
            body.velocity = Vector2.MoveTowards(body.velocity, new Vector2(0, body.velocity.y), 5.0f);    }

}
