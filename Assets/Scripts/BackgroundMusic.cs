using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour {
    [SerializeField] private static BackgroundMusic backgroundMusic;
    void Awake() {
        if (SceneManager.GetActiveScene().name == "Pong Game") {
            Destroy(gameObject);
        }
        else {
            if (backgroundMusic == null) {
                backgroundMusic = this;
                DontDestroyOnLoad(backgroundMusic);
            }
            else
                Destroy(gameObject);
        }
    }
}
