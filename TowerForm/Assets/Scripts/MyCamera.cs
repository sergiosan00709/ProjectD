using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {
	private float elapsed = 0f;
	public float rotationDuration;
	public float cameraHeight = 20f;
	public float yCamLerpSpeed;
	public bool transition = false;
	public float actionCooldown;
	private float nextAction;
	public GameObject player;
	public GameObject cameraGuide;
	void Awake(){
		cameraGuide.transform.position = transform.position;
		cameraGuide.transform.rotation = transform.rotation;
	}
    
	void Update(){
		
		if (transition == false){
			elapsed = 0f;
		}

		if (Input.GetKeyDown(KeyCode.A) && Time.time > nextAction && player.GetComponent<Character>().isGrounded == true){
			cameraGuide.transform.RotateAround(Vector3.zero, Vector3.up, -90f);
			nextAction = Time.time + actionCooldown;
			transition = true;
		}
		if (Input.GetKeyDown(KeyCode.D) && Time.time > nextAction && player.GetComponent<Character>().isGrounded == true){
			cameraGuide.transform.RotateAround(Vector3.zero, Vector3.up, +90f);
			nextAction = Time.time + actionCooldown;
			transition = true;
		}


	}

	void LateUpdate(){

		if (transform.position.y > player.transform.position.y -cameraHeight && transition == false){
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, player.transform.position.y + cameraHeight, transform.position.z), yCamLerpSpeed);
			cameraGuide.transform.position = transform.position;
		}

		if(transition == true){
			elapsed += Time.deltaTime / rotationDuration;
			transform.position = Vector3.Lerp(transform.position, cameraGuide.transform.position, elapsed);
			transform.rotation = Quaternion.Lerp(transform.rotation, cameraGuide.transform.rotation, elapsed);
			if(elapsed > 1f){
				transition = false;
			}
		}
	}
     
}
