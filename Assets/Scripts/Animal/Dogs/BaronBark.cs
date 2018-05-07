using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaronBark : MonoBehaviour {
	public AudioClip animalVoice;
	AudioSource audioSource;
	Animator animator;
	float idleTime; //idleステートの経過時間
	public float barkTriggerTime; //idleからHowlに変わるトリガーとなる時間

	void Start () {
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		idleTime = 0;
	}

	void Update(){
		//現在のアニメーターのステートを取得
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		//現在のステートがアイドルで、経過時間を過ぎたら吠える
		if (stateInfo.IsName("Idle")){
			idleTime += Time.deltaTime * 1.0f;
			if (idleTime > barkTriggerTime){
				animator.SetTrigger("Bark");
				idleTime = 0f;
			}
		} else {
			idleTime = 0f;
		}

	}
	
	//アニメーションのイベントで吠えるためのメソッドを呼び出す
	void PlayBark(){
		audioSource.PlayOneShot(animalVoice);
	}
}
