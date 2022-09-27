using System.Collections.Generic;
using UnityEngine;

public class SetupGame : MonoBehaviour {
    [SerializeField] private GameObject rightPaddle;
    [SerializeField] private GameObject ball;
    [SerializeField] private InvisibleBall invisibleBall;
    [SerializeField] private InvisiblePaddle invisiblePaddle1;
    [SerializeField] private InvisiblePaddle invisiblePaddle2;

    private List<string> modifiers = Modifiers.modifiers;

    [HideInInspector] public static float player1Speed = 10f, player2Speed;
    [HideInInspector] public float ballSpeed = 3f;

    void Start() {
        // Remove lobby music
        Destroy(GameObject.Find("Background Music"));

        // Game settings
        ballSpeed *= GameSettings.ballSpeed;
        player1Speed *= GameSettings.paddleSpeed;
        player2Speed = player1Speed;

        // Changes script based on CPU or human playing
        if (!PlayAgainst.playingHuman) {
            rightPaddle.GetComponent<CPU>().enabled = true;
        }
        else {
            rightPaddle.GetComponent<Player2>().enabled = true;
        }

        // Sets modifiers
        foreach (string mod in modifiers) {
            Debug.Log(mod);
            if (mod == "Bouncers Toggle")
                gameObject.GetComponent<Bouncers>().enabled = true;
            else if (mod == "Flashlight Toggle")
                gameObject.GetComponent<Flashlight>().enabled = true;
            else if (mod == "Invisible Ball Toggle")
                invisibleBall.enabled = true;
            else if (mod == "Invisible Paddle Toggle") {
                invisiblePaddle1.enabled = true;
                invisiblePaddle2.enabled = true;
            }
        }
    }
}
