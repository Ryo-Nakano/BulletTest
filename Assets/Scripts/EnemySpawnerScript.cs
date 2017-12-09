using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	[SerializeField] GameObject enemy;//Unity上からアタッチ
	[SerializeField] GameObject advancedEnemy;
	[SerializeField] GameObject homingEnemy;

	int enemyType;//乱数で取得！
	int enemySpawnPositionX;
//	Vector3 enemySpawnPosition = new Vector3 (enemySpawnPositionX, 16, 0);//Enemy生成する位置

	float enemySpawnTimer;//enemy生成の間隔

	// Use this for initialization
	void Start () {

		enemySpawnTimer = Random.Range (0,1.5f);
		
		//先ずゲーム開始と同時に8体のEnemy生成
		for(int i = 0; i < 8; i++)//8回回す
		{
			enemyType = Random.Range (1,4);
			EnemySpawn(enemyType);//Enemy生成
		}
	}
	
	// Update is called once per frame
	void Update () {

		//一定時間毎にEnemy生成
		enemySpawnTimer -= Time.deltaTime;
		if(enemySpawnTimer < 0)
		{
			for(int i = 0; i < 2; i++)
			{
				enemyType = Random.Range (1,4);
				EnemySpawn (enemyType);//Enemy生成
			}
			enemySpawnTimer = Random.Range (0,1.5f);
		}
	}

	//敵を生成する関数
	void EnemySpawn(int i)//引数にenemyTypeが入る！
	{
		if(i == 1)//enemyTyoeが1→普通のenemyの時
		{
			enemySpawnPositionX = Random.Range (-15, 15);//x軸のランダム取得
			Instantiate(enemy, new Vector3 (enemySpawnPositionX, 16, 0), Quaternion.identity);//enemyの生成
		}

		if(i == 2)//enemyTyoeが2→advancedEnemyの時
		{
			enemySpawnPositionX = Random.Range (-15, 15);//x軸のランダム取得
			Instantiate(advancedEnemy, new Vector3 (enemySpawnPositionX, 16, 0), Quaternion.identity);//enemyの生成
		}

		if(i == 3)//enemyTyoeが3→homingEnemyの時
		{
			enemySpawnPositionX = Random.Range (-15, 15);//x軸のランダム取得
			Instantiate(homingEnemy, new Vector3 (enemySpawnPositionX, 16, 0), Quaternion.identity);//enemyの生成
		}

	}
}
