using UnityEngine;
using System.Collections;

public class ItemEffects : MonoBehaviour {
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject player1Paddle;
    [SerializeField] private GameObject player2Paddle;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject ballObject;
    private Rigidbody2D rb;
    private GameObject playerShield;
    private GameObject newBall;

    void Awake() {
        rb = ball.GetComponent<Rigidbody2D>();
    }

    public void Apply(string name) {
        if (name == "Bigger Ball(Clone)") {
            StartCoroutine(BiggerBall());
        }
        else if (name == "Smaller Ball(Clone)") {
            StartCoroutine(SmallerBall());
        }
        else if (name == "Faster Ball(Clone)") {
            StartCoroutine(FasterBall());
        }
        else if (name == "Slower Ball(Clone)") {
            StartCoroutine(SlowerBall());
        }
        else if (name == "Bigger Paddle(Clone)") {
            StartCoroutine(BiggerPaddle());
        }
        else if (name == "Smaller Paddle(Clone)") {
            StartCoroutine(SmallerPaddle());
        }
        else if (name == "Faster Paddle(Clone)") {
            StartCoroutine(FasterPaddle());
        }
        else if (name == "Slower Paddle(Clone)") {
            StartCoroutine(SlowerPaddle());
        }
        else if (name == "Shield(Clone)") {
            StartCoroutine(Shield());
        }
        else if (name == "Split(Clone)") {
            Split();
        }
        else if (name == "Stun(Clone)") {
            StartCoroutine(Stun());
        }
    }

    private IEnumerator BiggerBall() {
        ball.transform.localScale *= 2;
        yield return new WaitForSeconds(3f);
        ball.transform.localScale /= 2;
    }

    private IEnumerator SmallerBall() {
        ball.transform.localScale /= 2;
        yield return new WaitForSeconds(3f);
        ball.transform.localScale *= 2;
    }

    private IEnumerator FasterBall() {
        rb.velocity *= 1.5f;
        yield return new WaitForSeconds(3f);
        rb.velocity /= 1.5f;
    }

    private IEnumerator SlowerBall() {
        rb.velocity /= 1.5f;
        yield return new WaitForSeconds(3f);
        rb.velocity *= 1.5f;
    }

    private IEnumerator BiggerPaddle() {
        if (ball.hit == 1) {
            player1Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize * 2);
            yield return new WaitForSeconds(5f);
            player1Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize);
        }
        else if (ball.hit == 2) {
            player2Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize * 2);
            yield return new WaitForSeconds(5f);
            player2Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize);
        }
    }

    private IEnumerator SmallerPaddle() {
        if (ball.hit == 2) {
            player1Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize / 2);
            yield return new WaitForSeconds(5f);
            player1Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize);
        }
        else if (ball.hit == 1) {
            player2Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize / 2);
            yield return new WaitForSeconds(5f);
            player2Paddle.transform.localScale = new Vector2(1, GameSettings.paddleSize);
        }
    }

    private IEnumerator FasterPaddle() {
        if (ball.hit == 1) {
            SetupGame.player1Speed *= 1.5f;
            yield return new WaitForSeconds(5f);
            SetupGame.player1Speed /= 1.5f;
        }
        else if (ball.hit == 2) {
            SetupGame.player2Speed *= 1.5f;
            yield return new WaitForSeconds(5f);
            SetupGame.player2Speed /= 1.5f;
        }
    }

    private IEnumerator SlowerPaddle() {
        if (ball.hit == 2) {
            SetupGame.player1Speed /= 1.5f;
            yield return new WaitForSeconds(5f);
            SetupGame.player1Speed *= 1.5f;
        }
        else if (ball.hit == 1) {
            SetupGame.player2Speed /= 1.5f;
            yield return new WaitForSeconds(5f);
            SetupGame.player2Speed *= 1.5f;
        }
    }

    private IEnumerator Shield() {
        if (ball.hit == 1) {
            playerShield = Instantiate(shield, new Vector2(-8.5f, 0f), Quaternion.identity);
        }
        else if (ball.hit == 2) {
            playerShield = Instantiate(shield, new Vector2(8.5f, 0f), Quaternion.identity);
        }
        yield return new WaitForSeconds(15f);
        Destroy(playerShield.gameObject);
    }

    private void Split() {
        if (ball.hit != 0) {
            newBall = Instantiate(ballObject, ball.gameObject.transform.position, Quaternion.identity);
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(ball.gameObject.GetComponent<Rigidbody2D>().velocity.x, ball.gameObject.GetComponent<Rigidbody2D>().velocity.y * -1);
        }
    }

    private IEnumerator Stun() {
        if (ball.hit == 1) {
            if (PlayAgainst.playingHuman) {
                player2Paddle.GetComponent<Player2>().enabled = false;
                yield return new WaitForSeconds(3f);
                player2Paddle.GetComponent<Player2>().enabled = true;
            }
            else {
                player2Paddle.GetComponent<CPU>().enabled = false;
                yield return new WaitForSeconds(3f);
                player2Paddle.GetComponent<CPU>().enabled = true;
            }
        }
        else if (ball.hit == 2) {
            player1Paddle.GetComponent<Player1>().enabled = false;
            yield return new WaitForSeconds(3f);
            player1Paddle.GetComponent<Player1>().enabled = true;
        }
    }
}