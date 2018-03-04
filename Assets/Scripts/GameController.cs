using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	public Text scoreText;
	private int score;

	void Start () {
		score = 0;
		updateScore();

		SpawnWaves();
	}

	void SpawnWaves () {
		Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate(hazard, spawnPosition, spawnRotation);
	}

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		updateScore();
	}

	void updateScore () {
		scoreText.text = "Score: " + score;
	}
}
