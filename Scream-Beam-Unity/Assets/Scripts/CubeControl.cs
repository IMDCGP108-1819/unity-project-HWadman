using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

	public float modifier;
	public GameObject audioController;
	public GameObject[] screenBounds;

	void Start () {
		
	}

	void Update () {  //Change position of player based on volume of microphone \/
		transform.position = new Vector3(-8,Mathf.Clamp(-4.5f + audioController.GetComponent<MicrophoneInput>().clipVolume * modifier * 1.5f,screenBounds[1].transform.position.y + 1.2f,screenBounds[0].transform.position.y - 1.2f),0);

	}
}