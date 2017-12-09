using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyController : MonoBehaviour {

	[SerializeField] GameObject homingBullet;//EnemyBulletのプレハブ置き場
	float bulletTimer;
	int bulletInterval;//EnemyBulletが発射される間隔(2秒から3秒間隔)

	Vector3 bulletPosition = new Vector3 (0, 1, 0);//BulletとEnemyの位置の差分
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
		//【Bulletが撃たれる頻度のコード】
		if(iCanShoot == true)
		{
			bulletInterval = Random.Range (3,7);
			iCanShoot = false;
		}

		bulletTimer += Time.deltaTime;//enemyBulletTimerスタート！
		if(bulletInterval < bulletTimer)
		{
			Instantiate (homingBullet, this.gameObject.transform.position - bulletPosition, Quaternion.identity);
			bulletTimer = 0;//タイマーを初期化！
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
