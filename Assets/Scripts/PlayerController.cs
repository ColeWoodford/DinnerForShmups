using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private Rigidbody2D playerRB2D;


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
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		} 		
	}
}
