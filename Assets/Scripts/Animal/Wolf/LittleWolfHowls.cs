using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleWolfHowls : MonoBehaviour {
	AudioClip getItemSound;
	AudioSource audioSource;
	Animator animator;
	float idleTime; //idleステートの経過時間
	public float howlTriggerTime; //idleからHowlに変わるトリガーとなる時間

	void Start () {
		getItemSound = Resources.Load<AudioClip>("LittleWolf #2");
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		idleTime = 0;
	}

	void Update(){
		//現在のアニメーターのステートを取得
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		//現在のステートがアイドルで、経過時間を過ぎたら吠える
		if (stateInfo.IsName("idle A")){
			idleTime += Time.deltaTime * 1.0f;
			if (idleTime > howlTriggerTime){
				animator.SetTrigger("Howl");
				idleTime = 0f;
			}
		} else {
			idleTime = 0f;
		}
	}
	
	//アニメーションのイベントで吠えるためのメソッドを呼び出す
	void PlayHowl(){
		audioSource.PlayOneShot(getItemSound);
	}
}
