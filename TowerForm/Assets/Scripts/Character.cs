using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public float actionCooldown;
	private float nextAction;
	private Animator anim;
	public GameObject player;
	public bool isGrounded;

	void Awake(){
		// isJumping = false;
		anim = GetComponent<Animator>();
	}

	void Start (){

	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.A) && Time.time > nextAction && isGrounded){
			transform.RotateAround (transform.position, Vector3.up, -90);
			nextAction = Time.time + actionCooldown;
		}

		if (Input.GetKeyDown(KeyCode.D) && Time.time > nextAction && isGrounded){
			transform.RotateAround (transform.position, Vector3.up, 90);
			nextAction = Time.time + actionCooldown;
		}


		if (Input.GetKeyDown(KeyCode.W) && Time.time > nextAction && isGrounded){
			nextAction = Time.time + actionCooldown;
			anim.SetTrigger("BasicJump");
		}

		if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextAction && isGrounded){
			nextAction = Time.time + actionCooldown + 0.2f;
			anim.SetTrigger("LongJump");
		}

	}


	public void RealocateCharacterPosition(){
		transform.position = new Vector3 (Mathf.Round(player.transform.position.x), player.transform.position.y, Mathf.Round(player.transform.position.z));
	}



}