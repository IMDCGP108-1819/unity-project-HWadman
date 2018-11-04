using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float modifier;
	public MicrophoneInput micInput;
	public GameObject[] screenBounds;
	
	public bool scream;
	public Menu menu;
	
	bool shoot;
	
	public GameObject[] beams;
	public float attackSpeed;
	
	void Start(){
		
		//transform.position = new Vector3(screenBounds[2].transform.position.x + 2,screenBounds[0].transform.position.y - 1.2f,0);
	}

	void Update () {  
		
		scream = menu.screamOn;
		
		//Change position of player based on volume of microphone if scream is enabled, else use keyboard/touch
		if(scream){
			
			float yPos = Mathf.Clamp(-4.5f + micInput.clipVolume * modifier * 1.5f,screenBounds[1].transform.position.y + 1.2f,screenBounds[0].transform.position.y - 1.2f);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(screenBounds[2].transform.position.x + 2,yPos,0),0.1f);
			
		}else{
			
			transform.position = new Vector3(screenBounds[2].transform.position.x + 2,transform.position.y,0);
			
			//bottom bounds
			if(transform.position.y >= screenBounds[1].transform.position.y + 1.2f){
				transform.position += new Vector3(0,-1,0) * Time.deltaTime * 4;
			}
			//keyboard and check for top bounds
			if(Input.GetKey(KeyCode.X)){
				if(transform.position.y >= screenBounds[0].transform.position.y - 1.2f){
					transform.position = new Vector3(screenBounds[2].transform.position.x + 2,screenBounds[0].transform.position.y - 1.2f,0);
				}
				transform.position += new Vector3(0,1,0) * Time.deltaTime * 9;
			}
			
			//touch and check for top bounds
			foreach(Touch touch in Input.touches){
				if (touch.position.x < Screen.width/2) {
					if(transform.position.y >= screenBounds[0].transform.position.y - 1.2f){
						transform.position = new Vector3(screenBounds[2].transform.position.x + 2,screenBounds[0].transform.position.y - 1.2f,0);
					}
					transform.position += new Vector3(0,1,0) * Time.deltaTime * 9;
				}
			}
		}
		
		//Touch shoot
		foreach(Touch touch in Input.touches){
			if(touch.position.x > Screen.width/2){
				if(shoot == false){
					StartCoroutine(Shoot());
				}
			}
		}
		//Keyboard shoot
		if(Input.GetKey(KeyCode.C)){
			if(shoot == false){
				StartCoroutine(Shoot());
			}
		}
	}
	
	IEnumerator Shoot(){
		shoot = true;
		while (shoot){
			
			//Check for an idle beam object to fire and then set its pos to the character pos and enable the beam script
			foreach(GameObject gO in beams){
				if(gO.GetComponent<Beam>().enabled == false){
					gO.transform.position = new Vector3(transform.position.x + 0.5f,transform.position.y - 0.2f,transform.position.z);
					gO.GetComponent<Beam>().enabled = true;
					break;
				}
			}
			
			yield return new WaitForSeconds(attackSpeed);
			shoot = false;
		}
	}
}