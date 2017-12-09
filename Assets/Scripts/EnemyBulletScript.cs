using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

	[SerializeField] float bulletSpeed;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();//Rigidbodyコンポーネント取得
		rb.velocity = new Vector3 (0, -bulletSpeed, 0);//速度ベクトルを代入
		Destroy (this.gameObject, 5f);//5秒後弾を破壊
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
