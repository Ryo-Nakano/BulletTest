using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour {

	Rigidbody rigidbody;
	[SerializeField] float playerBulletSpeed;
	GameManagerScript gm;

	// Use this for initialization
	void Start () {
		rigidbody = this.gameObject.GetComponent<Rigidbody> ();//Rigidbodyコンポーネント取得
		rigidbody.velocity = new Vector3 (0, playerBulletSpeed, 0);//速度ベクトルを代入

		gm = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();//GameManagerScriptを取得！
	}
	
	// Update is called once per frame
	void Update () {
		//playerBulletがある一定以上のところまで行った時、自動消滅
		if(this.gameObject.transform.position.y > 20f){
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "EnemyBullet") 
		{
			Destroy (this.gameObject);//PlayerBulletに当たったらDestroy
			Destroy(col.gameObject);
			gm.score += 1;//スコア加算

		}

		if (col.gameObject.tag == "Enemy") 
		{
			Destroy (this.gameObject);//PlayerBulletに当たったらDestroy
			Destroy(col.gameObject);///EnemyをDestroy
			gm.score += 5;//スコア加算
		}
	}
}
