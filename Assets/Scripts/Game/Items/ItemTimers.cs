using UnityEngine;
using UnityEngine.UI;

public class ItemTimers : MonoBehaviour {
    [SerializeField] private Image biggerBall;
    private float cooldown = 5f;
    void Start() {
        biggerBall.fillAmount = 1;
    }

    void Update() {
        biggerBall.fillAmount -= (1 / cooldown) * Time.deltaTime;
        if (biggerBall.fillAmount <= 0)
            biggerBall.fillAmount = 1;
    }
}
