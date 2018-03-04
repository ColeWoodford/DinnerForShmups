using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour 
{
	public float speed;
	// Use this for initialization
	private Rigidbody2D playerRB2D;
	void Start () 
	{
		playerRB2D = GetComponent<Rigidbody2D>();
		playerRB2D.velocity = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}