using UnityEngine;
using System.Collections.Generic;

public class Bouncers : MonoBehaviour {
    [SerializeField] private GameObject bouncer;
    public List<Vector2> bouncerPosList = new List<Vector2>();

    void Start() {
        float numberToSpawn = Mathf.Ceil(Random.Range(0f, 3f));
        Vector2 bouncerPos;

        for (int i = 0; i < numberToSpawn; i++) {
            do {
                bouncerPos = new Vector2(Random.Range(-7f, 7f), Random.Range(-4.2f, 4.2f));
            }
            while (!ValidatePosition(bouncerPos));
            bouncerPosList.Add(bouncerPos);
            Instantiate(bouncer, bouncerPos, Quaternion.identity);
        }
    }

    private bool ValidatePosition(Vector2 bouncerPos) {
        if ((Mathf.Abs(bouncerPos.x) < 1.5f && Mathf.Abs(bouncerPos.y) < 1.5f) || (Mathf.Abs(bouncerPos.x) < 1.5f && bouncerPos.y > 3.4f)) {
            return false;
        }
        for (int i = 0; i < bouncerPosList.Count; i++) {
            if ((bouncerPos - bouncerPosList[i]).sqrMagnitude < 2f) {
                return false;
            }
        }
        return true;
    }
}
