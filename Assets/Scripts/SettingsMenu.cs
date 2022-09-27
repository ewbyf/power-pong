using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class SettingsMenu : MonoBehaviour {
    private static SettingsMenu settings;
    private int firstPlay;
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    [SerializeField] private TextMeshProUGUI up1, up2, down1, down2;
    private GameObject currentKey;

    Resolution[] resolutions;

    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private TMP_Dropdown fullscreenDropdown;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;

    [SerializeField] private AudioMixer masterMixer;

    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(255, 0, 237, 255);

    [SerializeField] private GameObject quit;

    void Awake() {
        if (settings == null) {
            settings = this;
            DontDestroyOnLoad(settings);
        }
        else
            Destroy(gameObject);
    }

    void Start() {
        // Sets resolution options
        resolutions = Screen.resolutions;
        Array.Reverse(resolutions);

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height + " @ " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);

        // First time player preferences
        firstPlay = PlayerPrefs.GetInt("FirstPlay");
        if (firstPlay == 0) {
            PlayerPrefs.SetFloat("Music", 1f);
            PlayerPrefs.SetFloat("Effects", 1f);

            PlayerPrefs.SetString("Up1", KeyCode.W.ToString());
            PlayerPrefs.SetString("Down1", KeyCode.S.ToString());
            PlayerPrefs.SetString("Up2", KeyCode.UpArrow.ToString());
            PlayerPrefs.SetString("Down2", KeyCode.DownArrow.ToString());

            PlayerPrefs.SetInt("FirstPlay", -1);
        }
        LoadSettings();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().name == "Main Menu" || SceneManager.GetActiveScene().name == "Pong Game")
                if (settingsMenu.activeSelf)
                    CloseSettings();
                else
                    OpenSettings();
        }
    }

    public void LoadSettings() {
        qualityDropdown.value = PlayerPrefs.GetInt("Quality");
        SetQuality(PlayerPrefs.GetInt("Quality"));
        
        fullscreenDropdown.value = PlayerPrefs.GetInt("Fullscreen");
        SetFullscreen(PlayerPrefs.GetInt("Fullscreen"));

        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        SetResolution(PlayerPrefs.GetInt("Resolution"));

        musicSlider.value = PlayerPrefs.GetFloat("Music");
        masterMixer.SetFloat("musicVolume", Mathf.Log(PlayerPrefs.GetFloat("Music")) * 20);

        effectsSlider.value = PlayerPrefs.GetFloat("Effects");
        masterMixer.SetFloat("effectVolume", Mathf.Log(PlayerPrefs.GetFloat("Effects")) * 20);
        
        keys.Add("Up1", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up1")));
        keys.Add("Up2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up2")));
        keys.Add("Down1", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down1")));
        keys.Add("Down2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down2")));

        ChangeKeyString(up1, PlayerPrefs.GetString("Up1"));
        ChangeKeyString(up2, PlayerPrefs.GetString("Up2"));
        ChangeKeyString(down1, PlayerPrefs.GetString("Down1"));
        ChangeKeyString(down2, PlayerPrefs.GetString("Down2"));
    }

    public void OpenSettings() {
        if (SceneManager.GetActiveScene().name == "Pong Game")
            quit.SetActive(true);
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void CloseSettings() {
        if (SceneManager.GetActiveScene().name == "Pong Game")
            quit.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("Quality", qualityIndex);
    }

    public void SetFullscreen(int fullscreenIndex) {
        if (fullscreenIndex == 0)
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else if (fullscreenIndex == 1)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else if (fullscreenIndex == 2)
            Screen.fullScreenMode = FullScreenMode.Windowed;
        PlayerPrefs.SetInt("Fullscreen", fullscreenIndex);
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }

    public void SetMusic(float sliderValue) {
        masterMixer.SetFloat("musicVolume", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("Music", sliderValue);
    }

    public void SetEffect(float sliderValue) {
        masterMixer.SetFloat("effectVolume", Mathf.Log(sliderValue) * 20);
        PlayerPrefs.SetFloat("Effects", sliderValue);
    }

    void OnGUI() {
        if (currentKey != null) {
            Event e = Event.current;
            if (e.isKey) {
                if (e.keyCode != KeyCode.None) {
                    currentKey.GetComponent<Image>().color = normal;
                    if ((e.keyCode != keys["Up1"]) && (e.keyCode != keys["Up2"]) && (e.keyCode != keys["Down1"]) && (e.keyCode != keys["Down2"])) {
                        PlayerPrefs.SetString(currentKey.name, e.keyCode.ToString());
                        keys[currentKey.name] = e.keyCode;
                        ChangeKeyString(currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>(), e.keyCode.ToString());
                        currentKey = null;
                    }
                }
            }
        }
    }

    public void ChangeKey(GameObject clicked) {
        if (currentKey != null) {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;

    }

    private void ChangeKeyString(TextMeshProUGUI textObject, string text) {
        if (text == "DownArrow")
            textObject.text = "↓";
        else if (text == "UpArrow")
            textObject.text = "↑";
        else if (text == "RightArrow")
            textObject.text = "→";
        else if (text == "LeftArrow")
            textObject.text = "←";
        else
            textObject.text = text;
    }

    public void Quit() {
        SceneManager.LoadScene(0);
        CloseSettings();
    }
}

