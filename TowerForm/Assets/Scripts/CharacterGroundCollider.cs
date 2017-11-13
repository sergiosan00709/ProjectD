using UnityEngine;

public class CharacterGroundCollider : MonoBehaviour {
	public GameObject player;

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Ground"){
			player.GetComponent<Character>().isGrounded = true;
		}
	}

	void OnTriggerExit (Collider col){
		if (col.tag == "Ground"){
			player.GetComponent<Character>().isGrounded = false;
		}
	}
}
