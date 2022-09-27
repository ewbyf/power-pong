using UnityEngine;

public class Flashlight : MonoBehaviour {
    [SerializeField] private GameObject fog;
    [SerializeField] private GameObject flashlight;

    void Start() {
        fog.SetActive(true);
        flashlight.SetActive(true);
    }

    void Update() {
        flashlight.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }
}
