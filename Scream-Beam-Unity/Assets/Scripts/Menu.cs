using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
	
	public GameObject player;
	public MicrophoneInput micIn;
	
	public bool screamOn;
	
	public GameObject[] mainMenu;
	
	void Update(){
		//make sure screaming cant be on if there is no mic
		if(!micIn.micOn && screamOn){
			screamOn = false;
		}
	}
	
	public void Play(){
		for (int i = 0; i < mainMenu.Length; i++){
			mainMenu[i].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
		}
	}
	
	public void Scream(){
		//check if there is a mic before allowing the player to enable the mic
		if(screamOn){
			screamOn = false;
		}else if(!screamOn && micIn.micOn){
			screamOn = true;
		}
	}
	
	public void Info(){
	}
}
