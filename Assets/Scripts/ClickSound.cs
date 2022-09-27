using UnityEngine;

public class ClickSound : MonoBehaviour {
    [SerializeField] private GameObject clickSFX;
    public void PlaySound() {
        GameObject sound = Instantiate(clickSFX, transform.position, transform.rotation);
        DontDestroyOnLoad(sound);
    }
}
