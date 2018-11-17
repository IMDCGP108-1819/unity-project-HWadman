using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
	public GameObject left;
	
	public int maxHealth = 1;
	public int health;
	
	public GameObject[] clouds;
	
	public bool canFire;
	public float fireDelay;
	public float fireUpTime;
	public GameObject[] bullets;
	
	public Game game;
	public PlayerControl player;
	
	void OnEnable()
    {
        health = maxHealth;
		fireUpTime = Time.time;
    }

    void Update(){
		//Move left
        transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
		//If past left boundary reset
        if(transform.position.x < left.transform.position.x - 2.5f){
			Reset();
		}
		if(health <= 0){
			game.score += 15;
			player.audio.clip = player.sounds[2];
			player.audio.volume = 0.08f;
			player.audio.Play();
			GetCloud();
			Reset();
		}
		
		//if the enemy can shoot then fire a bullet evey (fireDelay) seconds
		if(canFire){
			if(Time.time > fireUpTime){
				GameObject gO = GetBullet();
				gO.transform.position = this.transform.position;
				gO.GetComponent<Bullet>().enabled = true;
				fireUpTime += fireDelay;
			}
		}
    }
	
	IEnumerator hit(){
		health -= 1;
		yield return new WaitForSeconds(1f);
	}
	
	public void Reset(){
		//reset health, move off-screen and disable this script
		health = maxHealth;
		transform.position = new Vector3(left.transform.position.x - 2.5f,0,0);
		gameObject.GetComponent<Enemy>().enabled = false;
	}
	
	void GetCloud(){
		foreach (GameObject gO in clouds){
            if (gO.activeSelf == false){
                gO.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-7f);
				gO.SetActive(true);
				gO.GetComponent<Cloud>().StartCoroutine("Reset");
				break;
            }
        }
	}
	
	GameObject GetBullet(){
		foreach (GameObject gO in bullets){
			if(gO.GetComponent<Bullet>().enabled == false){
				//gO.transform.position = this.transform.position;
				//gO.GetComponent<Bullet>().enabled = true;
				return gO;
			}
		}
		return null;
	}
}
