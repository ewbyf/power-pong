using UnityEngine;

public class Player2 : MonoBehaviour {
    private float speed;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start() {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Update() {
        float directionY = 0;
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up2"))))
            directionY = 1f;
        else if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down2"))))
            directionY = -1f;
        direction = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate() {
        speed = SetupGame.player2Speed;
        rb.velocity = direction * speed;
    }
}
