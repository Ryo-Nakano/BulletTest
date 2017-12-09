using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] float speed;
	[SerializeField] GameObject playerBullet;

	Vector3 bulletPosition = new Vector3 (0, 0.85f, 0);//BulletとPlayerの位置の差分

	float bulletTimer;
	[SerializeField] float bulletInterval;//bullatを撃つインターバルを変更する変数
	bool iCanAttack = true;//攻撃できるかどうかを司る変数！

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//======================================================================================

		//【自機の移動】

		//左キー押した時左に移動
		if(Input.GetKey("left") == true)
		{
			if(this.transform.position.x > -15)
			{
				this.gameObject.transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
			}
		}
		//右キー押した時右に移動
		if(Input.GetKey("right") == true)
		{
			if(this.transform.position.x < 15)
			{
				this.gameObject.transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
			}
		}

		//======================================================================================

		//【弾発射のコード】

		bulletTimer += Time.deltaTime;//bulletTimerスタート！

		//スペースキー押した時弾発射
		if(Input.GetKey("space") == true)
		{
			if(bulletTimer >= bulletInterval)
			{
				Instantiate (playerBullet, this.transform.position + bulletPosition, Quaternion.identity);

				bulletTimer = 0;//bulletTimerの初期化！

			}

		}
			
	}
}
