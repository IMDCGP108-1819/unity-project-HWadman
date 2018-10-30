using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float modifier;
	public MicrophoneInput micInput;
	public GameObject[] screenBounds;
	
	public bool scream;
	public Menu menu;
	
	public int touch; // if touch = 0 then no touch, 1 = left screen touch, 2 = right screen touch

	void Update () {  
		
		scream = menu.screamOn;
		
		//Change position of player based on volume of microphone if scream is enabled, else use keyboard/touch
		if(scream){
			
			float yPos = Mathf.Clamp(-4.5f + micInput.clipVolume * modifier * 1.5f,screenBounds[1].transform.position.y + 1.2f,screenBounds[0].transform.position.y - 1.2f);
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(-8,yPos,0),0.1f);
			
		}else{
			
			//bottom bounds
			if(transform.position.y >= screenBounds[1].transform.position.y + 1.2f){
				transform.position += new Vector3(0,-1,0) * Time.deltaTime * 4;
			}
			//keyboard
			if(Input.GetKey(KeyCode.X)){
				if(transform.position.y >= screenBounds[0].transform.position.y - 1.2f){
					transform.position = new Vector3(-8,screenBounds[0].transform.position.y - 1.2f,0);
				}
				transform.position += new Vector3(0,1,0) * Time.deltaTime * 9;
			}
			//touch
			
		}
	}
}