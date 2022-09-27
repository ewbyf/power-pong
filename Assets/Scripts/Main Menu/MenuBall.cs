using UnityEngine;
using System.Collections;

public class MenuBall : MonoBehaviour {
    private Rigidbody2D rb;
    private float speed = 4f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        StartCoroutine(Launch());
    }

    public IEnumerator Launch() {
        transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
        speed = 4f;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        yield return new WaitForSeconds(.5f);

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Left Paddle" || collision.gameObject.name == "Right Paddle") {
            float positionX;
            float positionY = (transform.position.y - collision.transform.position.y) * 3 / (collision.collider.bounds.size.y);

            // Adds bonus speed
            if (speed < 7f)
                speed += 1f;

            if (collision.gameObject.name == "Left Paddle")
                positionX = 1f;
            else
                positionX = -1f;

            rb.velocity = new Vector2(speed * positionX, speed * positionY);
        }

        if (collision.gameObject.name == "Left Border" || collision.gameObject.name == "Right Border")
            StartCoroutine(Launch());
    }
}
