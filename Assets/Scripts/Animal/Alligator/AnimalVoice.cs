using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalVoice : MonoBehaviour {
	public AudioClip animalVoice;
	AudioSource audioSource;
	float time;
	float voiceTriggerTime;
	public float minPlayTime;
	public float maxPlayTime;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		time = 0;
		voiceTriggerTime = Random.Range(minPlayTime, maxPlayTime);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * 1.0f;
		if (time > voiceTriggerTime){
			PlayVoice();
			time = 0;
		}
	}

	void PlayVoice(){
		audioSource.PlayOneShot(animalVoice);
	}
}
