using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerSideDown : MonoBehaviour
{
	public float speed;
	public float speedAfterLock;
	//public Transform target;
	//public float tumble;
	public float horizontalMagnitude;
	public float verticalMagnitude;
	public bool isLeft;
	public float xPos;

	private Rigidbody2D enemyRB2D;

	// Use this for initialization
	void Start ()
	{
		// Initializes the rigidbody so we can use it
		enemyRB2D = GetComponent<Rigidbody2D>();
		//normalizeDirection = (target.position - transform.position).normalized;
		//enemyRB2D.angularVelocity = tumble;
	}

	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	// Because the RigidBody2D is a physics object, we use this
	void FixedUpdate()
	{
		if(isLeft)
		{
			if(enemyRB2D.position.x < xPos)
			{
				Vector2 movement = new Vector2(horizontalMagnitude, verticalMagnitude);
				enemyRB2D.velocity = movement * speed;
			}
			else
			{
				Vector2 movement = new Vector2(0, -1);

				enemyRB2D.velocity = movement * speedAfterLock;
			}
		}
		else
		{
			if(enemyRB2D.position.x > xPos)
			{
				Vector2 movement = new Vector2(horizontalMagnitude, verticalMagnitude);
				enemyRB2D.velocity = movement * speed;
			}
			else
			{
				Vector2 movement = new Vector2(0, -1);

				enemyRB2D.velocity = movement * speedAfterLock;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.position = transform.position + (normalizeDirection * speed * Time.deltaTime);
	}
}