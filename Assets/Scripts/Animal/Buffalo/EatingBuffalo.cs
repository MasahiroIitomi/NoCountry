using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingBuffalo : MonoBehaviour {
	Animator animator;
	float idleTime; //経過時間
	public float triggerTime;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		idleTime = 0f;	
	}
	
	// Update is called once per frame
	void Update () {
		idleTime += Time.deltaTime * 1.0f;
		if (idleTime > triggerTime){
			animator.SetTrigger("Eat");
			idleTime = 0f;
		}
	}
}
