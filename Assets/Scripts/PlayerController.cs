﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GameObject period_shot;
	public GameObject comma_shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public float fireRate;
	public float fireRate2;
	private float nextFire;
	private float nextFire2;
	private Rigidbody2D playerRB2D;
	public Boundary boundary;



	// Use this for initialization
	void Start ()
	{
		// Initializes the rigidbody so we can use it
		playerRB2D = GetComponent<Rigidbody2D>();
	}

	// FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	// Because the RigidBody2D is a physics object, we use this
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		playerRB2D.velocity = movement * speed;

		playerRB2D.position = new Vector3
		(
			Mathf.Clamp (playerRB2D.position.x, boundary.xMin, boundary.xMax), 
			Mathf.Clamp (playerRB2D.position.y, boundary.yMin, boundary.yMax),
			0.0f
		);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (period_shot, shotSpawn1.position, shotSpawn1.rotation);
		} 		
		else if (Input.GetButton("Fire2") && Time.time > nextFire2)
		{
			nextFire2 = Time.time + fireRate2;
			Instantiate (comma_shot, shotSpawn2.position, shotSpawn2.rotation);
		} 		
	}
}
