using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerStraight : MonoBehaviour
{
	public float speed;
	//public Transform target;
	//public float tumble;
	public float horizontalMagnitude;
	public float verticalMagnitude;

	private Rigidbody2D enemyRB2D;

	// Use this for initialization
	void Start ()
	{
		// Initializes the rigidbody so we can use it
		enemyRB2D = GetComponent<Rigidbody2D>();
	}

	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	// Because the RigidBody2D is a physics object, we use this
	void FixedUpdate()
	{
		Vector2 movement = new Vector2(horizontalMagnitude, verticalMagnitude);

		enemyRB2D.velocity = movement * speed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.position = transform.position + (normalizeDirection * speed * Time.deltaTime);
	}
}