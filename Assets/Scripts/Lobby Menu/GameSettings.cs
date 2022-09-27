using UnityEngine;
using TMPro;
using System;

public class GameSettings : MonoBehaviour {
    [HideInInspector] public static int scoreToWin = 7;
    [HideInInspector] public static float ballSize = 1f;
    [HideInInspector] public static float ballSpeed = 1f;
    [HideInInspector] public static float itemSpawn = 10f;
    [HideInInspector] public static float paddleSize = 1f;
    [HideInInspector] public static float paddleSpeed = 1f;

    private int[] scoreToWinArray = {3, 5, 7, 10, 15};
    private float[] ballSizeArray = {.5f, .75f, 1f, 1.25f, 1.5f};
    private float[] ballSpeedArray = {.5f, .75f, 1f, 1.25f, 1.5f};
    private float[] itemSpawnArray = {5f, 7.5f, 10f, 12.5f, 15f};
    private float[] paddleSizeArray = {.5f, .75f, 1f, 1.25f, 1.5f};
    private float[] paddleSpeedArray = {.5f, .75f, 1f, 1.25f, 1.5f};

    public void Plus(GameObject obj) {
        if (obj.name == "Score to Win Value") {
            int index = Array.IndexOf(scoreToWinArray, scoreToWin);
            if (index < scoreToWinArray.Length - 1) {
                index++;
                scoreToWin = scoreToWinArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{scoreToWinArray[index]}";
            }
        }
        else if (obj.name == "Ball Size Value") {
            int index = Array.IndexOf(ballSizeArray, ballSize);
            if (index < ballSizeArray.Length - 1) {
                index++;
                ballSize = ballSizeArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{ballSizeArray[index]}x";
            }
        }
        else if (obj.name == "Ball Speed Value") {
            int index = Array.IndexOf(ballSpeedArray, ballSpeed);
            if (index < ballSpeedArray.Length - 1) {
                index++;
                ballSpeed = ballSpeedArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{ballSpeedArray[index]}x";
            }
        }
        else if (obj.name == "Item Spawn Value") {
            int index = Array.IndexOf(itemSpawnArray, itemSpawn);
            if (index < itemSpawnArray.Length - 1) {
                index++;
                itemSpawn = itemSpawnArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{itemSpawnArray[index]}x";
            }
        }
        else if (obj.name == "Paddle Size Value") {
            int index = Array.IndexOf(paddleSizeArray, paddleSize);
            if (index < paddleSizeArray.Length - 1) {
                index++;
                paddleSize = paddleSizeArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{paddleSizeArray[index]}x";
            }
        }
        else if (obj.name == "Paddle Speed Value") {
            int index = Array.IndexOf(paddleSpeedArray, paddleSpeed);
            if (index < paddleSpeedArray.Length - 1) {
                index++;
                paddleSpeed = paddleSpeedArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{paddleSpeedArray[index]}x";
            }
        }
    }

    public void Minus(GameObject obj) {
        if (obj.name == "Score to Win Value") {
            int index = Array.IndexOf(scoreToWinArray, scoreToWin);
            if (index > 0) {
                index--;
                scoreToWin = scoreToWinArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{scoreToWinArray[index]}";
            }
        }
        else if (obj.name == "Ball Size Value") {
            int index = Array.IndexOf(ballSizeArray, ballSize);
            if (index > 0) {
                index--;
                ballSize = ballSizeArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{ballSizeArray[index]}x";
            }
        }
        else if (obj.name == "Ball Speed Value") {
            int index = Array.IndexOf(ballSpeedArray, ballSpeed);
            if (index > 0) {
                index--;
                ballSpeed = ballSpeedArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{ballSpeedArray[index]}x";
            }
        }
        else if (obj.name == "Item Spawn Value") {
            int index = Array.IndexOf(itemSpawnArray, itemSpawn);
            if (index > 0) {
                index--;
                itemSpawn = itemSpawnArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{itemSpawnArray[index]}x";
            }
        }
        else if (obj.name == "Paddle Size Value") {
            int index = Array.IndexOf(paddleSizeArray, paddleSize);
            if (index > 0) {
                index--;
                paddleSize = paddleSizeArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{paddleSizeArray[index]}x";
            }
        }
        else if (obj.name == "Paddle Speed Value") {
            int index = Array.IndexOf(paddleSpeedArray, paddleSpeed);
            if (index > 0) {
                index--;
                paddleSpeed = paddleSpeedArray[index];
                obj.GetComponent<TextMeshProUGUI>().text = $"{paddleSpeedArray[index]}x";
            }
        }
    }
}
