using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	//read keys input
	float dirX;
	// move speed variable available to set in Inspector
	public float moveSpeed= 10f;
	
	// Update is called once per frame
	void Update () {
		//input left-right keys
		dirX = Input.GetAxis("Horizontal");

		//set game objects position depending on keys input
		//move speed and deltaTime values
		transform.position = new Vector2 (
			transform.position.x + dirX + moveSpeed * Time.deltaTime,
			transform.position.y);
	}//end Update

}//end MovePlayer
