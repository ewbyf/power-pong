using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectionButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private GameObject lobbyMenu;
    [SerializeField] private GameObject itemsMenu;
    [SerializeField] private GameObject modifiersMenu;
    [SerializeField] private GameObject tooltip;
    private Color blue = new Color(0, 200, 255);

    void Start() {
        GameObject lobby = GameObject.Find("Lobby Button");
        
        lobby.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = blue;
        lobby.GetComponent<Outline>().enabled = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    public void Clicked() {
        // Adds effect to button when clicked
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = blue;
        gameObject.GetComponent<Outline>().enabled = true;

        // Change other buttons back to original
        button1.GetComponent<Outline>().enabled = false;
        button1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;

        button2.GetComponent<Outline>().enabled = false;
        button2.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;

        if (gameObject.name == "Lobby Button") {
            lobbyMenu.SetActive(true);
            itemsMenu.SetActive(false);
            modifiersMenu.SetActive(false);
        }
        else if (gameObject.name == "Items Button") {
            lobbyMenu.SetActive(false);
            itemsMenu.SetActive(true);
            modifiersMenu.SetActive(false);
            // tooltip.transform.position = new Vector3(420, 133, 0);

        }
        else if (gameObject.name == "Modifiers Button") {
            lobbyMenu.SetActive(false);
            itemsMenu.SetActive(false);
            modifiersMenu.SetActive(true);
            // tooltip.transform.position = new Vector3(420, 120, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
     {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = blue;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
        if (!gameObject.GetComponent<Outline>().enabled) {
            gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.white;
        }
     }
}
