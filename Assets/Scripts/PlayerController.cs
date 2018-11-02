using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	[SerializeField] float speed;
	[SerializeField] GameObject playerBullet;

	Vector3 bulletPosition = new Vector3 (0, 0.85f, 0);//BulletとPlayerの位置の差分

	float bulletTimer;
	[SerializeField] float bulletInterval;//bullatを撃つインターバルを変更する変数
	//bool iCanAttack = true;//攻撃できるかどうかを司る変数！


	void Update () {

		Move ();//Playerの移動
		Shoot();//Playerが弾を打つ関数
	}


    //===============以下、自作関数===============

    //Playerの移動を司る関数
	void Move()
	{
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
	}

    //Playerが弾を打つ関数
	void Shoot()
	{
		bulletTimer += Time.deltaTime;//bulletTimerスタート！

        //スペースキー押した時弾発射
        if (Input.GetKey("space") == true)
        {
            if (bulletTimer >= bulletInterval)
            {
                Instantiate(playerBullet, this.transform.position + bulletPosition, Quaternion.identity);

                bulletTimer = 0;//bulletTimerの初期化！
            }
        }
	}
}
