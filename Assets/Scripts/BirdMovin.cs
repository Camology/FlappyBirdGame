using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdMovin : MonoBehaviour {

	public float speed = 2;
	public float force = 300;
	private Rigidbody2D rb;
	public Text time;
	private int levelsWon;
	private int timesDied; 
	// Use this for initialization

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
		levelsWon = PlayerPrefs.GetInt ("levelsWon");
		timesDied = PlayerPrefs.GetInt ("timesDied");
	}
	void Start () {
		rb.velocity = Vector2.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce(Vector2.up * force);
		}
		time.text = "Score: " + Time.timeSinceLevelLoad  + "\n" 
			+"Levels you've conquered : " + levelsWon + "\n"
			+"Birds you've let down: " + timesDied;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Die") {
			PlayerPrefs.SetInt ("timesDied", ++timesDied);
			PlayerPrefs.Save ();
			reloadScene ();
		}
		if (col.gameObject.tag == "NextLevel") {
			PlayerPrefs.SetInt ("levelsWon", ++levelsWon);
			PlayerPrefs.Save ();
			reloadScene();
		}


	}

	void reloadScene() {
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}


}
