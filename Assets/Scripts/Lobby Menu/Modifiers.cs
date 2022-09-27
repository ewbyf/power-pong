using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modifiers : MonoBehaviour {
    public static List<string> modifiers = new List<string>();
    private bool local = Localize.isLocal;

    void Start() {
        if (local) {
            GameObject.Find("Flashlight").transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    
    // When start button is clicked, all enabled modifiers will be added to list
    public void ListItems() {
        modifiers.Clear();

        foreach (Transform child in transform) {
            if (child.GetChild(1).GetComponent<Toggle>().isOn) {
                modifiers.Add(child.GetChild(1).name);
            }
        }
    }
}
