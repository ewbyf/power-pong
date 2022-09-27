using UnityEngine;
using System.Collections;

public class InvisibleBall : MonoBehaviour {
    Gradient invisibleGradient;
    GradientColorKey[] invisibleColorKey;
    GradientAlphaKey[] invisibleAlphaKey;

    Gradient defaultGradient;
    GradientColorKey[] defaultColorKey;
    GradientAlphaKey[] defaultAlphaKey;


    void Start() {
        // Invis gradient
        invisibleGradient = new Gradient();

        invisibleColorKey = new GradientColorKey[2];
        invisibleColorKey[0].color = new Color(0f, 0f , 0f, 0f);
        invisibleColorKey[0].time = 0f;
        invisibleColorKey[1].color = new Color(0f, 0f , 0f, 0f);
        invisibleColorKey[1].time = 1f;

        invisibleAlphaKey = new GradientAlphaKey[2];
        invisibleAlphaKey[0].alpha = 0f;
        invisibleAlphaKey[0].time = 0f;
        invisibleAlphaKey[1].alpha = 0f;
        invisibleAlphaKey[1].time = 1f;
        invisibleGradient.SetKeys(invisibleColorKey, invisibleAlphaKey);

        // Default gradient
        defaultGradient = new Gradient();

        defaultColorKey = new GradientColorKey[2];
        defaultColorKey[0].color = new Color32(255, 238, 47, 150);
        defaultColorKey[0].time = 0f;
        defaultColorKey[1].color = new Color32(255, 255, 255, 0);
        defaultColorKey[1].time = 1f;

        defaultAlphaKey = new GradientAlphaKey[2];
        defaultAlphaKey[0].alpha = .589f;
        defaultAlphaKey[0].time = 0f;
        defaultAlphaKey[1].alpha = 0f;
        defaultAlphaKey[1].time = 1f;
        defaultGradient.SetKeys(defaultColorKey, defaultAlphaKey);

        StartCoroutine(SetInvisible());
    }

    private IEnumerator SetInvisible() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0f, 10f));
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            GetComponent<TrailRenderer>().colorGradient = invisibleGradient;
            yield return new WaitForSeconds(Random.Range(0f, 5f));
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 255);
            GetComponent<TrailRenderer>().colorGradient = defaultGradient;
        }
    }
}
