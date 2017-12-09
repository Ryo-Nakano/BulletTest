using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedEnemyController : MonoBehaviour {

	[SerializeField] GameObject advancedEnemyBullet;//EnemyBulletのプレハブ置き場
	float bulletTimer;
	int bulletInterval;//EnemyBulletが発射される間隔(2秒から3秒間隔)
	//	int enemyBulletInterval = 3;

	Vector3 bulletPosition = new Vector3 (0, 0.85f, 0);//BulletとEnemyの位置の差分
	bool iCanShoot = true;//EnemyBulletの生成を司る

	[SerializeField] float advancedEnemySpeed;//Enemyの移動速度


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
			bulletInterval = Random.Range (2,4);//2か3を取得
			iCanShoot = false;
		}

		bulletTimer += Time.deltaTime;//enemyBulletTimerスタート！
		if(bulletInterval < bulletTimer)
		{
			Instantiate (advancedEnemyBullet, this.gameObject.transform.position - bulletPosition, Quaternion.identity);
			bulletTimer = 0;//タイマーを初期化！
			iCanShoot = true;
		}
		//===========================================
		//【Enemyの進行に関するコード】
		this.gameObject.transform.position += new Vector3 (0, -advancedEnemySpeed * Time.deltaTime, 0);

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy (col.gameObject);//PlayerBulletに当たったらPlayerをDestroy
		}
	}
}
