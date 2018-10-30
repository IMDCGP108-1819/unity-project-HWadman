using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour {
	
	AudioSource audioSource;
	
	float updateEvery = 0.05f;
	int sampleLength = 1024;
	float updateTracker;
	float[] clipSample;
	int counter;
	public float clipVolume;
	
	public bool micOn;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		
		// Start recording default mic if there is a mic
		if(Microphone.devices.Length > 0){
			audioSource.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate); 
		}
	}
	
	void Update(){
		
		if(Microphone.devices.Length > 0){
			micOn = true;
		}else{
			micOn = false;
		}
		
		if(audioSource.clip != null){
			updateTracker += Time.deltaTime;														//Run this code \/
			if (updateTracker >= updateEvery) {														//every (updateEvery) seconds
			
				clipSample = new float[audioSource.clip.samples * audioSource.clip.channels];		// Init array for samples, clip length in sample * number of channels
			
				updateTracker = 0f;
				audioSource.clip.GetData(clipSample, audioSource.timeSamples);						//sample the audio clip and store the samples in the clip sample array
				clipVolume = 0f;																	//audioSource.timeSamples refrences the current time of the audio clip
				foreach (var sample in clipSample) {
					clipVolume += Mathf.Abs(sample);												//Find the average volume
				}																					//of all samples
				clipVolume /= sampleLength;
			}
		}
	}
}