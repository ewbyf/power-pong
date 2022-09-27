using UnityEngine;

public class OpenSettings : MonoBehaviour {
    private GameObject settings;
    void Start() {
        settings = GameObject.Find("Settings");
    }

    public void Open() {
        settings.GetComponent<SettingsMenu>().OpenSettings();
    }
}
