using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffaloVoice : MonoBehaviour {
	AudioClip getItemSound;
	AudioSource audioSource;
	float time;
	float voiceTriggerTime;

	void Start () {
		getItemSound = Resources.Load<AudioClip>("Buffalo");
		audioSource = GetComponent<AudioSource>();
		time = 0;
		voiceTriggerTime = Random.Range(20.0f, 120.0f);
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
		audioSource.PlayOneShot(getItemSound);
	}
}
