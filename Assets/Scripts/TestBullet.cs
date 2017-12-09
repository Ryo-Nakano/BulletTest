using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : MonoBehaviour {

	[SerializeField] float enemyBulletSpeed;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody> ();//Rigidbodyコンポーネント取得
		rb.velocity = transform.up * enemyBulletSpeed;
	}

	// Update is called once per frame
	void Update () {

	}
		
}
