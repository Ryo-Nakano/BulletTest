using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] GameObject enemyBullet;//EnemyBulletのプレハブ置き場
	float enemyBulletTimer;
	int enemyBulletInterval;//EnemyBulletが発射される間隔(2秒から3秒間隔)
//	int enemyBulletInterval = 3;

	Vector3 bulletPosition = new Vector3 (0, 0.85f, 0);//BulletとEnemyの位置の差分
	bool iCanShoot = true;//EnemyBulletの生成を司る

	[SerializeField] float enemySpeed;//Enemyの移動速度


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//===========================================
		//【EnemyBulletが撃たれる頻度のコード】
		if(iCanShoot == true)
		{
			enemyBulletInterval = Random.Range (2,4);//2か3を取得
			iCanShoot = false;
		}
			
		enemyBulletTimer += Time.deltaTime;//enemyBulletTimerスタート！
		if(enemyBulletInterval < enemyBulletTimer)
		{
			Instantiate (enemyBullet, this.gameObject.transform.position - bulletPosition, Quaternion.identity);
			enemyBulletTimer = 0;//タイマーを初期化！
			iCanShoot = true;
		}


		//===========================================
		//【Enemyの進行に関するコード】
		this.gameObject.transform.position += new Vector3 (0, -enemySpeed * Time.deltaTime, 0);
		
	}

//	void OnTriggerEnter(Collider col)
//	{
//		if (col.gameObject.tag == "PlayerBullet") 
//		{
//			Destroy (this.gameObject);//PlayerBulletに当たったらDestroy
//		}
//	}
}
