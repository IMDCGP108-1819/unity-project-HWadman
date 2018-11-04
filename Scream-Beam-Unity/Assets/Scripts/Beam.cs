using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {
	
	public float speed;
	bool hasReset;

	void Update () {
		transform.position += new Vector3(1,0,0) * speed * Time.deltaTime;
		if(!hasReset){
			StartCoroutine(Reset());
		}
	}
	
	IEnumerator Reset(){
		hasReset = true;
		yield return new WaitForSeconds(4f);
		hasReset = false;
		gameObject.GetComponent<Beam>().enabled = false;
	}
}