using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class ItemsMenu : MonoBehaviour {
    [SerializeField] private GameObject blind;
    public static List<string> items = new List<string>();
    private bool local = Localize.isLocal;

    void Start() {
        if (local) {
            blind.SetActive(false);
        }
    }

    // For enable all toggle button
    public void EnableAllToggle() {
        if (transform.Find("Enable All Toggle").GetComponent<Toggle>().isOn) {
            foreach (Transform child in transform) {
                child.GetComponent<Toggle>().isOn = true;
            }
        }
        else if (!(transform.Find("Enable All Toggle").GetComponent<Toggle>().isOn)) {
            foreach (Transform child in transform) {
                child.GetComponent<Toggle>().isOn = false;
            }
        }
    }

    // When start button is clicked, all enabled items will be added to list
    public void ListItems() {
        items.Clear();
        foreach (Transform child in transform) {
            if (child.GetComponent<Toggle>().isOn && child.name != "Enable All Toggle") {
                if (!(child.name == "Blind" && local))
                    items.Add(child.name);
            }
        }
    }
}
