using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Canvas扱う！
using UnityEngine.SceneManagement;//シーン遷移扱う！

public class GameOverSceneManager : MonoBehaviour {

	[SerializeField] Text lastScoreText;
	[SerializeField] Text highScoreText;

	int lastScore;//LastScoreを格納！
	int highScore;//HighScoreを格納！


	void Awake(){//Startよりも先に呼ばれる！
		lastScore = PlayerPrefs.GetInt ("LastScore");//Scoreの名前で保存してあるデータを取ってきて、lastScoreに格納
	}

	// Use this for initialization
	void Start () {
		//HighScore選別
		if(PlayerPrefs.HasKey("HighScore") == false){//HighScoreが存在しない時
			highScore = lastScore;//lastScoreをhighScoreにして、
			PlayerPrefs.SetInt ("HighScore", lastScore);//HighScoreデータとして格納

		}else{//HighScore存在する時
			highScore = PlayerPrefs.GetInt("HighScore");

			if (highScore < lastScore) {//直近の結果の方がhighScoreよりも高かった時
				highScore = lastScore;//highScoreにlastSccoreを代入して
				PlayerPrefs.SetInt ("HighScore",lastScore);//lastScoreの値をHighScoreとして保存
			}
		}
			
		//スコア表示
		lastScoreText.text = "LastScore : " + lastScore;
		highScoreText.text = "HighScore : " + highScore;
		
	}
	
	public void Retry()
	{
		SceneManager.LoadScene("InGame");//GameOverシーンへ移動
	}
}
