using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン遷移扱う
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	[SerializeField] GameObject player;//Unity上からアタッチ
	public int score;
	[SerializeField] Text scoreText;//スコア表示！

	float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = "Score :" + score.ToString ();//スコア表示！

		if(player.gameObject == null){//PlayerがDestroyされた時
			timer += Time.deltaTime;

			PlayerPrefs.SetInt("LastScore", score);//scoreの値をLastScoreの名前で保存！
			SceneManager.LoadScene("GameOver");//GameOverシーンへ移動
		}


	}
}
