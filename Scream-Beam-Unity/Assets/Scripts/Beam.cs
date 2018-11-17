using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {
	
	public float speed;
	public GameObject right;

	void Update () {
		//Move right
		transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
		//If past right boundary disable this script
		if(transform.position.x > right.transform.position.x + 4f){
			Reset();
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Enemy"){
			//Send the hit message to enemy hit
			other.GetComponent<Enemy>().StartCoroutine("hit");
			Reset();
		}
	}
	
	public void Reset(){
		//move off-screen and disable script
		transform.position = new Vector3(right.transform.position.x + 4f,0,0);
		gameObject.GetComponent<Beam>().enabled = false;
	}
}