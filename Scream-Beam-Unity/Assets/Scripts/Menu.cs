using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public GameObject player;
	public MicrophoneInput micIn;
	
	public bool screamOn;
	public GameObject[] mainMenu;
	
	public Game game;
	
	void Update(){
		//make sure screaming cant be on if there is no mic
		if(!micIn.micOn && screamOn){
			screamOn = false;
		}
		
		//Change the main menu scream to show if scream is enabled or disabled
		if(screamOn){
			if(!game.isPlaying){
				mainMenu[2].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);	//enable the scream ✔️
				mainMenu[3].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);	//disable the scream X
			}
		}else{
			if(!game.isPlaying){
				mainMenu[2].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);	//disable the scream ✔️
				mainMenu[3].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);	//enable the scream X
			}
		}
	}
	
	// On play disable all menus, and start the game
	public void Play(){
		for (int i = 0; i < mainMenu.Length; i++){
			mainMenu[i].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			mainMenu[i].GetComponent<Image>().enabled = false;
		}
		game.isPlaying = true;
	}
	
	public void Scream(){
		//check if there is a mic before allowing the player to enable screaming
		if(screamOn){
			screamOn = false;
		}else if(!screamOn && micIn.micOn){
			screamOn = true;
		}
	}
	
	public void Info(){
	}
	
	public void StopPlaying(){
		
	}
}
