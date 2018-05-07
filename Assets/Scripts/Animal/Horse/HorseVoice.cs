using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseVoice : MonoBehaviour {
	AudioClip getHorseSound;
	AudioSource audioSource;
	float time;
	float voiceTriggerTime;

	void Start () {
		getHorseSound = Resources.Load<AudioClip>("Horse Neigh 1");
		audioSource = GetComponent<AudioSource>();
		time = 0;
		voiceTriggerTime = Random.Range(20.0f, 60.0f);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * 1.0f;
		if (time > voiceTriggerTime){
			PlayHorseVoice();
			time = 0;
		}
	}

	void PlayHorseVoice(){
		audioSource.PlayOneShot(getHorseSound);
	}
}
