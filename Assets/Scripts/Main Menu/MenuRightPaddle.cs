using UnityEngine;

public class MenuRightPaddle : MonoBehaviour {
    [SerializeField] private Rigidbody2D ball;
    private Rigidbody2D rb;
    private float speed = 10f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
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
