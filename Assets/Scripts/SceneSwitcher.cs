using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour{

    private ScoreManager scoreManager;

    void Start(){
        GameObject g = GameObject.Find("ScoreManager");
        if(g != null)
            scoreManager = g.GetComponent<ScoreManager>();
    }

    public void LoadLevel(int i) {
        if(scoreManager != null)
            PlayerPrefs.SetInt(ScorePrefs.PREVIOUS_SCORE, scoreManager.score);
        SceneManager.LoadScene("Level_" + i);
    }
}
