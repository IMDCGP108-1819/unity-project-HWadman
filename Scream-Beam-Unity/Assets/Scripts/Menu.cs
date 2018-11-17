using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
		
		mainMenu[6].GetComponent<TextMeshProUGUI>().text = Mathf.Round(game.score).ToString();
		
		if(!game.isPlaying){
			mainMenu[0].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);	//enable all menu sprites
			mainMenu[0].GetComponent<Image>().enabled = true;
			mainMenu[1].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			mainMenu[1].GetComponent<Image>().enabled = true;
			mainMenu[4].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			mainMenu[4].GetComponent<Image>().enabled = true;
			mainMenu[5].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			mainMenu[6].GetComponent<TextMeshProUGUI>().faceColor = new Color(1f,1f,1f,1f);
			if(screamOn){
				mainMenu[2].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);	//if scream is enabled turn on the scream tick sprite
				mainMenu[2].GetComponent<Image>().enabled = true;
				mainMenu[3].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
				mainMenu[3].GetComponent<Image>().enabled = false;
			}else{
				mainMenu[3].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);	//if scream is disabled turn on the scream cross sprite
				mainMenu[3].GetComponent<Image>().enabled = true;
				mainMenu[2].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
				mainMenu[2].GetComponent<Image>().enabled = false;
			}
		}else{
			mainMenu[0].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);	//disable all menu sprites
			mainMenu[0].GetComponent<Image>().enabled = false;
			mainMenu[1].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			mainMenu[1].GetComponent<Image>().enabled = false;
			mainMenu[2].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			mainMenu[2].GetComponent<Image>().enabled = false;
			mainMenu[3].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			mainMenu[3].GetComponent<Image>().enabled = false;
			mainMenu[4].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			mainMenu[4].GetComponent<Image>().enabled = false;
			mainMenu[5].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
			mainMenu[6].GetComponent<TextMeshProUGUI>().faceColor = new Color(1f,1f,1f,0f);
		}
	}
	
	// On play disable all menus, reset score and start the game
	public void Play(){
		game.score = 0;
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
		mainMenu[7].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
		mainMenu[7].GetComponent<Image>().enabled = true;
	}
	public void CloseInfo(){
		mainMenu[7].GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
		mainMenu[7].GetComponent<Image>().enabled = false;
	}
}
