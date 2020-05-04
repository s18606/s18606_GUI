using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{
	
	private float animationTime =0;
    private Animator anim;
	private ScoreManager scoreManager;
	private bool collected;
	public int points = 1;

	
    void Start(){
		scoreManager = GameObject.Find("ScoreManagerObject").GetComponent<ScoreManager>();
		collected = false;
		

    }

    private void OnTriggerEnter2D(Collider2D collision) {
		if(collision.gameObject.CompareTag("Player") && !collected) {
			scoreManager.IncrementScore(points);
			Invoke("CollectCoin", animationTime);
			
		}

    }
	
	private void CollectCoin() {
		Destroy(gameObject);
	}

}
