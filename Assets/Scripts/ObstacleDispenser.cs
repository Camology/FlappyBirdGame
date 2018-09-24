using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDispenser : MonoBehaviour {

	public GameObject obstacle;
	// Use this for initialization
	void Start () {
		int rand = Random.Range (10, 25);
		for (int i = 0; i < rand; i++) {
			Instantiate (obstacle);
		}
	}
}
