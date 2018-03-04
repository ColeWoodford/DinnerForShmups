using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
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
			gameController.GameOver();
		}

		Destroy(other.gameObject);

		health = health - 10;
		if (health == 0) {
			gameController.AddScore (scoreValue);
			Destroy(gameObject);
		}
	}
}
