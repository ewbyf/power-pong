using UnityEngine;

public class EndGame : MonoBehaviour {
    [SerializeField] private SpawnItems spawnItems;
    [SerializeField] private ItemEffects itemEffects;
    [SerializeField] private Ball ball;
    [SerializeField] private Player1 player1;
    [SerializeField] private Player2 player2;
    [SerializeField] private CPU cpu;
    [SerializeField] private GameObject fog;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private InvisibleBall invisibleBall;
    [SerializeField] private InvisiblePaddle invisiblePaddle;
    [SerializeField] private InvisiblePaddle invisiblePaddle2;
    
    public void endGame() {
        Destroy(ball.gameObject);
        player1.enabled = false;
        player2.enabled = false;
        cpu.enabled = false;
        fog.SetActive(false);
        spawnItems.StopAllCoroutines();
        itemEffects.StopAllCoroutines();
        flashlight.SetActive(false);
        invisibleBall.StopAllCoroutines();
        invisiblePaddle.StopAllCoroutines();
        invisiblePaddle2.StopAllCoroutines();
    }
}
