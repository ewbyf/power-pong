using UnityEngine;
using System.Collections;

public class InvisiblePaddle : MonoBehaviour {
    void Start() {
        StartCoroutine(SetInvisible());
    }

    private IEnumerator SetInvisible() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0f, 10f));
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(Random.Range(0f, 5f));
            GetComponent<SpriteRenderer>().color = new Color32(0, 194, 255, 255);
        }
    }
}