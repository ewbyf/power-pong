using UnityEngine;
using UnityEngine.UI;

public class PlayAgainst : MonoBehaviour {
    private bool local = Localize.isLocal;
    [SerializeField] private GameObject playersObject;
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject bot;
    [HideInInspector] public static bool playingHuman = true;


    void Start() {
        if (!local) {
            gameObject.SetActive(false);
            playersObject.SetActive(true);
        }
    }

    public void HumanSelect() {
        ColorBlock cb = human.GetComponent<Button>().colors;
        cb.normalColor = cb.pressedColor;
        cb.highlightedColor = cb.pressedColor;
        human.GetComponent<Button>().colors = cb;

        cb.normalColor = cb.disabledColor;
        cb.highlightedColor = cb.disabledColor;
        bot.GetComponent<Button>().colors = cb;

        playingHuman = true;
    }

    public void BotSelect() {
        ColorBlock cb = bot.GetComponent<Button>().colors;
        cb.normalColor = cb.pressedColor;
        cb.highlightedColor = cb.pressedColor;
        bot.GetComponent<Button>().colors = cb;

        cb.normalColor = cb.disabledColor;
        cb.highlightedColor = cb.disabledColor;
        human.GetComponent<Button>().colors = cb;
        
        playingHuman = false;
    }

}
