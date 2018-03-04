using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	private int health;
	private GameController gameController;
	public float colourChangeDelay = 0.5f;
 	float currentDelay = 0f;
 	bool colourChangeCollision = false;

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

	void Update()
	{
    	checkColourChange();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Boundary") {
			return;
		}

		colourChangeCollision = true;
     	currentDelay = Time.time + colourChangeDelay;
		Destroy(other.gameObject);

		health = health - 10;
		if (health == 0) {
			gameController.AddScore (scoreValue);
			Destroy(gameObject);
		}
	}

	void checkColourChange()
	{        
    	if(colourChangeCollision)
    	{
        	transform.renderer.material.color = Color.yellow;
        	if(Time.time > currentDelay)
        	{
            	transform.renderer.material.color = Color.white;
            	colourChangeCollision = false;
        	}
    	}
	}
}
