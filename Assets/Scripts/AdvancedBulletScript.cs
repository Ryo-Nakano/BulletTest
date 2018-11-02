using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedBulletScript : MonoBehaviour {

	GameObject player;//Playerを格納しておく
	Vector3 targetPosition;//bulletを飛ばす方向

	[SerializeField] float advancedBulletSpeed;//弾が進むスピード
	Rigidbody rb;//Rigidbodyを格納しておく為の変数

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();//Rigidbodyコンポーネント取得！
		player = GameObject.Find ("Player");//Player見つけてきて変数playerに格納

		if(player != null)
		{
			targetPosition = (player.transform.position - this.transform.position).normalized;//bulletを飛ばす方向ベクトルを取得→正規化(単位ベクトル化)
			rb.velocity = targetPosition * advancedBulletSpeed;//方向ベクトル*大きさをvelosityに代入
			this.transform.up = targetPosition;//弾をplayerの方向に向けさせる→y軸の正方向に一致させる
		}


		Destroy (this.gameObject, 10f);//10秒後弾を破壊
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Destroy (col.gameObject);//PlayerBulletに当たったらPlayerをDestroy
		}
	}


}
