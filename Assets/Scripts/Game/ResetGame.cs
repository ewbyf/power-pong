using UnityEngine;

public class ResetGame : MonoBehaviour {
    [SerializeField] private GameObject ball;
    [SerializeField] private Ball ballHit;
    [SerializeField] private GameObject paddle1;
    [SerializeField] private GameObject paddle2;
    [SerializeField] private ItemEffects effects;
    [SerializeField] private SetupGame setup;
    private Rigidbody2D rb;
    private float defaultPlayerSpeed = 10f * GameSettings.paddleSpeed;

    void Awake() {
        rb = ball.GetComponent<Rigidbody2D>();
    }

    public void Reset() {
        // Resets item effects
        effects.StopAllCoroutines();

        // Resets ball
        ball.transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
        ball.transform.localScale = new Vector2(GameSettings.ballSize, GameSettings.ballSize);

        // Resets paddles
        SetupGame.player1Speed = defaultPlayerSpeed;
        SetupGame.player2Speed = defaultPlayerSpeed;
        paddle1.transform.localScale = new Vector2(1, GameSettings.paddleSize);
        paddle2.transform.localScale = new Vector2(1, GameSettings.paddleSize);
        paddle1.GetComponent<Player1>().enabled = true;
        if (PlayAgainst.playingHuman)
                paddle2.GetComponent<Player2>().enabled = true;
        else
            paddle2.GetComponent<CPU>().enabled = true;

        ballHit.hit = 0;

        foreach (GameObject shield in GameObject.FindGameObjectsWithTag("Shield")) {
            if(shield.name == "Player Shield(Clone)")
                Destroy(shield);
        }
    }
}
