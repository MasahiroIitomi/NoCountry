using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantRandomEat : MonoBehaviour {
    Animator animator;
	float time;
	float eatTriggerTime;
	public float minPlayTime;
	public float maxPlayTime;

	void Start () {
		animator = GetComponent<Animator>();
		time = 0;
		eatTriggerTime = Random.Range(minPlayTime, maxPlayTime);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * 1.0f;
		if (time > eatTriggerTime){
			PlayEat();
			time = 0;
		}
	}

	void PlayEat(){
        animator.SetTrigger("Eat");
	}
}
