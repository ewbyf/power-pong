using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnItems : MonoBehaviour {
    private float spawnTime = GameSettings.itemSpawn;
    private List<string> items = ItemsMenu.items;
    private Vector2 itemPos;
    public List<Vector2> itemPosList = new List<Vector2>();
    
    [SerializeField] private Bouncers bouncers;
    [SerializeField] private GameObject biggerPaddle;
    [SerializeField] private GameObject smallerPaddle;
    [SerializeField] private GameObject fasterPaddle;
    [SerializeField] private GameObject slowerPaddle;
    [SerializeField] private GameObject biggerBall;
    [SerializeField] private GameObject smallerBall;
    [SerializeField] private GameObject fasterBall;
    [SerializeField] private GameObject slowerBall;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject stun;
    [SerializeField] private GameObject split;
    [SerializeField] private GameObject blind;

    void Start() {
        if (items.Count > 0) {
            StartCoroutine(spawnItem());
        }
    }

    private IEnumerator spawnItem() {
        while (true) {
            do {
                itemPos = new Vector2(Random.Range(-7f, 7f), Random.Range(-4.2f, 4.2f));
            }
            while (!ValidatePosition(itemPos));

            yield return new WaitForSeconds(spawnTime);

            switch(items[(int)Mathf.Ceil(Random.Range(-1f, items.Count-1))]) {
                case "Bigger Paddle":
                    Instantiate(biggerPaddle, itemPos, Quaternion.identity);
                    break;
                case "Smaller Paddle":
                    Instantiate(smallerPaddle, itemPos, Quaternion.identity);
                    break;
                case "Faster Paddle":
                    Instantiate(fasterPaddle, itemPos, Quaternion.identity);
                    break;
                case "Slower Paddle":
                    Instantiate(slowerPaddle, itemPos, Quaternion.identity);
                    break;
                case "Bigger Ball":
                    Instantiate(biggerBall, itemPos, Quaternion.identity);
                    break;
                case "Smaller Ball":
                    Instantiate(smallerBall, itemPos, Quaternion.identity);
                    break;
                case "Faster Ball":
                    Instantiate(fasterBall, itemPos, Quaternion.identity);
                    break;
                case "Slower Ball":
                    Instantiate(slowerBall, itemPos, Quaternion.identity);
                    break;
                case "Shield":
                    Instantiate(shield, itemPos, Quaternion.identity);
                    break;
                case "Stun":
                    Instantiate(stun, itemPos, Quaternion.identity);
                    break;
                case "Split":
                    Instantiate(split, itemPos, Quaternion.identity);
                    break;
                case "Blind":
                    Instantiate(blind, itemPos, Quaternion.identity);
                    break;
            }
            itemPosList.Add(itemPos);
        }
    }

    private bool ValidatePosition(Vector2 itemPos) {
        if (Mathf.Abs(itemPos.x) < 1.5f && itemPos.y > 3.4f) {
            return false;
        }
        for (int i = 0; i < bouncers.bouncerPosList.Count; i++) {
            if ((itemPos - bouncers.bouncerPosList[i]).sqrMagnitude < 2f) {
                return false;
            }
        }
        for (int i = 0; i < itemPosList.Count; i++) {
            if ((itemPos - itemPosList[i]).sqrMagnitude < 2f) {
                return false;
            }
        }
        return true;
    }
}
