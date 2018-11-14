using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
	public GameObject left;
	
	public int maxHealth = 1;
	int health;
	
	void OnEnable()
    {
        health = maxHealth;
    }

    void Update(){
		//Move left
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
		//If past left reset
        if(transform.position.x < left.transform.position.x - 2.5f){
			Reset();
		}
		if(health <= 0){
			Reset();
		}
    }
	
	IEnumerator hit(){
		health -= 1;
		yield return new WaitForSeconds(1f);
	}
	
	public void Reset(){
		health = maxHealth;
		transform.position = new Vector3(left.transform.position.x - 2.5f,0,0);
		gameObject.GetComponent<Enemy>().enabled = false;
	}
}
