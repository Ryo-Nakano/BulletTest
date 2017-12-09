using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletScript : MonoBehaviour {

	GameObject player;
	Vector3 targetPosition;//bulletを飛ばす方向

	[SerializeField] float homingBulletSpeed;//弾が飛ぶスピード
	Rigidbody rb;

	float homingTimer = 0.5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();//Rigidbodyコンポーネント取得！
		player = GameObject.Find ("Player");//Player見つけてきて変数playerに格納
	}
	
	// Update is called once per frame
	void Update () {

		//0.5s毎に敵の方向をアップデートして追従
		homingTimer -= Time.deltaTime;
		if(homingTimer < 0){
			Homing ();//Homing関数を呼ぶ
			homingTimer = 0.5f;//Timerのリセット
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy (col.gameObject);//PlayerBulletに当たったらPlayerをDestroy
		}
	}

	//敵追従の関数
	void Homing()
	{
		if(player != null)
		{
			targetPosition = (player.transform.position - this.transform.position).normalized;//bulletを飛ばす方向ベクトルを取得→正規化(単位ベクトル化)
			rb.velocity = targetPosition * homingBulletSpeed;//方向ベクトル*大きさをvelosityに代入
		}
	}
}
