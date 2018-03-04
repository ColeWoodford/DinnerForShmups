using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	public GameObject explosion;
	public GameObject hit;
	public float explodeTime;
	public float hitTime;

	private int health;
	private GameController gameController;

	void Start () {
		health = scoreValue;

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Boundary") {
			return;
		}
		if (other.tag == "Player") {
			var explode = Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(explode, explodeTime);
			gameController.GameOver();
		}
		
		var onHit = Instantiate(hit, other.transform.position, other.transform.rotation);
		Destroy(onHit, hitTime);

		Destroy(other.gameObject);

		health = health - 10;
		if (health == 0) {
			gameController.AddScore (scoreValue);
			var explode = Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
			Destroy(explode, explodeTime);
		}
	}
}
