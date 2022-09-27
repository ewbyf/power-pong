using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ResetGame reset;
    [SerializeField] private SetupGame setup;
    [SerializeField] private SpawnItems items;
    private Rigidbody2D rb;
    private float speed;
    [HideInInspector] public int hit = 0;
    private int borderBounces = 0;
    private bool lastHitPaddle = false;

    [SerializeField] private GameObject hitSFX;
    [SerializeField] private GameObject scoreSFX;
    [SerializeField] private GameObject bouncerSFX;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        if (gameObject.name == "Ball") {
            StartCoroutine(Launch());
        }
    }

    public IEnumerator Launch() {
        // Resets ball
        reset.Reset();

        borderBounces = 0;
        
        speed = setup.ballSpeed;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        yield return new WaitForSeconds(1.5f);

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public IEnumerator bouncerBoost() {
        GetComponent<TrailRenderer>().startWidth = .15f * gameObject.transform.localScale.x;
        GetComponent<TrailRenderer>().enabled = true;
        rb.velocity *= 1.5f;

        yield return new WaitForSeconds(1f);

        GetComponent<TrailRenderer>().enabled = false;
        if (!lastHitPaddle)
            rb.velocity /= 1.5f;
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        // Collides with a paddle
        if (collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2") {
            Instantiate(hitSFX, transform.position, transform.rotation);

            // Checks if it's a cloned ball
            if (gameObject.name == "Ball(Clone)") {
                Destroy(gameObject);
            }
            // If not cloned
            else {
                borderBounces = 0;
                
                if (collision.gameObject.name == "Player 1") {
                    hit = 1;
                }
                else if (collision.gameObject.name == "Player 2") {
                    hit = 2;
                }

                float positionX;
                float positionY = (transform.position.y - collision.transform.position.y) * 3 / collision.collider.bounds.size.y;

                // Adds bonus speed
                if (speed < 10f * GameSettings.ballSpeed)
                    speed += 1f * GameSettings.ballSpeed;

                if (collision.gameObject.name == "Player 1")
                    positionX = 1f;
                else
                    positionX = -1f;

                // Adds new speed to ball
                rb.velocity = new Vector2(speed * positionX, speed * positionY);

                lastHitPaddle = true;
            }
        }

        else if (collision.gameObject.name == "Top Border" || collision.gameObject.name == "Bottom Border") {
            Instantiate(hitSFX, transform.position, transform.rotation);
            lastHitPaddle = false;
            borderBounces++;
            if (borderBounces >= 12 && gameObject.name == "Ball") {
                StartCoroutine(Launch());
            }
        }

        // Collides with a bouncer
        else if (collision.gameObject.name == "Bouncer(Clone)") {
            Instantiate(bouncerSFX, transform.position, transform.rotation);
            if (gameObject.name == "Ball") {
                borderBounces = 0;
            }
            lastHitPaddle = false;
            StartCoroutine(bouncerBoost());
        }

        // Collides with shield
        else if (collision.gameObject.name == "Shield(Clone)") {
            Instantiate(hitSFX, transform.position, transform.rotation);
            lastHitPaddle = false;
            Destroy(collision.gameObject);
            if (gameObject.name == "Ball(Clone)") {
                Destroy(gameObject);
            }
            else {
                borderBounces = 0;
            }
        }

        // Scoring
        else if (collision.gameObject.name == "Left Border") {
            Instantiate(scoreSFX, transform.position, transform.rotation);
            gameManager.Player2Goal();
            if (gameObject.name == "Ball(Clone)")
                Destroy(gameObject);
            else if (gameManager.player2Score != gameManager.scoreToWin)
                StartCoroutine(Launch());
        }
        else if (collision.gameObject.name == "Right Border") {
            Instantiate(scoreSFX, transform.position, transform.rotation);
            gameManager.Player1Goal();
            if (gameObject.name == "Ball(Clone)")
                Destroy(gameObject);
            else if (gameManager.player1Score != gameManager.scoreToWin)
                StartCoroutine(Launch());
        }

    }
}
