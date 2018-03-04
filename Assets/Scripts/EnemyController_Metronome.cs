using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Metronome : MonoBehaviour {

	private Vector3 pos1 = new Vector3 (-5.8f, 4.26f, 0);
	private Vector3 pos2 = new Vector3 (5.8f, 4.26f, 0);

	public float markerSpeed = 1.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.Lerp (pos1, pos2, (Mathf.Sin (markerSpeed * Time.time) + 1.0f) / 2.0f);
	}
}
