using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI player1Text;
    [SerializeField] private TextMeshProUGUI player2Text;
    [SerializeField] private EndGame end;
    [SerializeField] private TextMeshProUGUI winner;
    [SerializeField] private GameObject gameOver;
    [HideInInspector] public int player1Score = 0;
    [HideInInspector] public int player2Score = 0;
    [HideInInspector] public int scoreToWin = GameSettings.scoreToWin;

    public void Player1Goal() {
        player1Score++;
        player1Text.text = $"{player1Score}";
        CheckScore();
    }

    public void Player2Goal() {
        player2Score++;
        player2Text.text = $"{player2Score}";
        CheckScore();
    }

    private void CheckScore() {
        if (player1Score == scoreToWin || player2Score == scoreToWin) {
            end.endGame();
            if (player1Score == scoreToWin) {
                player1Text.color = new Color32(78, 255, 125, 255);
                player2Text.color = new Color32(255, 79, 79, 255);
            }
            else if (player2Score == scoreToWin) {
                player2Text.color = new Color32(78, 255, 125, 255);
                player1Text.color = new Color32(255, 79, 79, 255);
                winner.text = "Player 2 Wins!";
            }

            gameOver.SetActive(true);

        }
    }

}
