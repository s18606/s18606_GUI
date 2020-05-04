using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour{

    public Text scoreText;
    public Text highScoreText;
    public int score;
    private int highScore;

    private void Awake() {
        if (PlayerPrefs.HasKey(ScorePrefs.SCORE))
            score = PlayerPrefs.GetInt(ScorePrefs.SCORE);
        else {
            score = 0;
            PlayerPrefs.SetInt(ScorePrefs.SCORE, score);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.PREVIOUS_SCORE)) {
            score = PlayerPrefs.GetInt(ScorePrefs.PREVIOUS_SCORE);
            PlayerPrefs.SetInt(ScorePrefs.SCORE, score);
        } else {
            PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_SCORE, score);
        }

        if (PlayerPrefs.HasKey(ScorePrefs.HIGH_SCORE))
            highScore = PlayerPrefs.GetInt(ScorePrefs.HIGH_SCORE);
        else {
            PlayerPrefs.SetInt(ScorePrefs.HIGH_SCORE, 0);
        }        
    }

    void Update(){
        scoreText.text = "Score: " + score;
        highScoreText.text = "High score: " + highScore;

        if(score > highScore) {
            PlayerPrefs.SetInt(ScorePrefs.HIGH_SCORE, score);
            highScore = score;
        }
    }

    public void IncrementScore(int i) {
        score += i;
        PlayerPrefs.SetInt(ScorePrefs.SCORE, score);
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt(ScorePrefs.HIGH_SCORE, score);
        PlayerPrefs.SetInt(ScorePrefs.SCORE, 0);
        PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_SCORE, 0);
        PlayerPrefs.Save();
    }
}
