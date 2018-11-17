using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	public float speed;
	public GameObject left;
	
	void Update () {
		//Move left
		transform.position += new Vector3(-1,0,0) * speed * Time.deltaTime;
		//If past left boundary disable this script
		if(transform.position.x < left.transform.position.x - 2.5f){
			Reset();
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			//Send the hit message to enemy hit
			other.GetComponent<PlayerControl>().StartCoroutine("Damage",1);
			Reset();
		}
	}
	
	public void Reset(){
		//move off-screen and disable this script
		transform.position = new Vector3(left.transform.position.x - 2.5f,0,0);
		gameObject.GetComponent<Bullet>().enabled = false;
	}
}
