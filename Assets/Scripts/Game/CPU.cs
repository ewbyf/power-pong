using UnityEngine;

public class CPU : MonoBehaviour {
    [SerializeField] private Rigidbody2D ball;
    private Rigidbody2D rb;
    private float speed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        speed = SetupGame.player2Speed;
        if (ball.velocity.x > 0.0f) {
            if (ball.position.y > transform.position.y) {
                rb.AddForce(Vector2.up * speed);
            }
            else if (ball.position.y < transform.position.y) {
                rb.AddForce(Vector2.down * speed);
            }
        }
        else {
            if (transform.position.y > 0.0f) {
                rb.AddForce(Vector2.down * speed);
            }
            else if (transform.position.y < 0.0f) {
                rb.AddForce(Vector2.up * speed);
            }
        }
    }
}
