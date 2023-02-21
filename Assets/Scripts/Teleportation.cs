using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {
	public Transform teleportTarget;
	public GameObject player;

	private bool playerReached = false;

	void OnTriggerEnter(Collider other){
		// player.transform.position = teleportTarget.transform.position;
		playerReached = true;
	}

	void Update(){
		if (playerReached && Input.GetKeyUp(KeyCode.T)){
			player.transform.position = teleportTarget.transform.position;
		}
	}

	void OnTriggerExit(Collider other){
		playerReached = false;
	}
}
