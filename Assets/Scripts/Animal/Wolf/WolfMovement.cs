using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class WolfMovement : MonoBehaviour {
	Animator animator;
	public Transform goal;
	public NavMeshAgent agent;
	float distance;
	public float runSpeed;
	public float walkSpeed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void Update (){
		distance = Vector3.Distance(transform.position, goal.position);
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

		if(stateInfo.IsName("idle A") || stateInfo.IsName("run") || stateInfo.IsName("walk"))
		{
			agent.SetDestination(goal.position);
			//10m以上であれば走ってくる
			if (distance > 10.0f)
			{
				animator.SetBool("Run", true);
				agent.speed = runSpeed;
			} 
			//3m以上なら歩いてくる
			else if (distance > 3.0f)
			{
				animator.SetBool("Run", false);
				animator.SetBool("Walk", true);
				agent.speed = walkSpeed;	
			}
			//それ以下ならアイドル状態に戻る
			else
			{
				animator.SetBool("Walk", false);			
			}
		}
	}
}