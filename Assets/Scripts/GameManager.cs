using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text gameOverText;
    private bool gameOver;

    void Start() {
        gameOver = false;
    }

    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                PlayerPrefs.SetInt(ScorePrefs.SCORE, 0);
                PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_SCORE, 0);
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void GameOver() {
        gameOverText.text = "GAME OVER - press 1 to reset, press 2 to go to the MENU";
        gameOver = true;
        PlayerPrefs.SetInt(ScorePrefs.SCORE, PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_SCORE));
    }
}