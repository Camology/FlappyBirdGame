using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = 0;
	public float switchTime = 2;
	// Use this for initialization

	void Awake() {
		float rand = Random.Range (0f, 1f);
		Debug.Log (rand);
		float x = Random.Range (-4f, 40f);
		float y = Random.Range (-8.5f, -4f);
		if (rand > 0.5f) {
			transform.localScale = new Vector3 (1, -1, 1);
			y *= -1f;
			Debug.Log (y);
		}
		transform.position = new Vector2 (x, y);
		speed = Random.Range (0, 3);
	}
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;

		InvokeRepeating ("Switch", 0, switchTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Switch() {
		GetComponent<Rigidbody2D> ().velocity *= -1;
	}
}
