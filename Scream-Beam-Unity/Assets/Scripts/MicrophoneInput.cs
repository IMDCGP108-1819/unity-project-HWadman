using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneInput : MonoBehaviour {
	
	AudioSource audioSource;
	
	float updateEvery = 0.1f;
	int sampleLength = 1024;
	float updateTracker;
	public float clipVolume;
	float[] clipSample;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = Microphone.Start(null, true, 1, AudioSettings.outputSampleRate); // Start recording default mic
		clipSample = new float[audioSource.clip.samples * audioSource.clip.channels];		// Init array for samples, clip length in sample * number of channels
	}
	
	void Update(){
		
		if(audioSource.clip != null){
			updateTracker += Time.deltaTime;												//Run this code \/
			if (updateTracker >= updateEvery) {												//every (updateEvery) seconds
				updateTracker = 0f;
				audioSource.clip.GetData(clipSample, audioSource.timeSamples);				//sample the audio clip and store the samples in the clip sample array
				clipVolume = 0f;															//audioSource.timeSamples refrences the current time of the audio clip
				foreach (var sample in clipSample) {
					clipVolume += Mathf.Abs(sample);										//Find the average volume
				}																			//of all samples
				clipVolume /= sampleLength;
			}
		}
		
	}
	
	void StartMic () {
		if(Microphone.devices.Length > 0){
			
		}else{
			print("No mic connected");
		}
	}
}