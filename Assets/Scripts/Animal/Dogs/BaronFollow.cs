using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class BaronFollow : MonoBehaviour {
	Animator animator;
	public Transform target;
	NavMeshAgent agent;
	float distance;
	public float runSpeed;
	public float walkSpeed;

	public float runDistance;
	public float stopDistance;

	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void Update (){
		distance = Vector3.Distance(transform.position, target.position);
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

		if (stateInfo.IsName("Idle") || stateInfo.IsName("Run") || stateInfo.IsName("Walk")){
			agent.SetDestination(target.position);
			//指定距離以上であれば走ってくる
			if (distance > runDistance)
			{
				animator.SetBool("Run", true);
				agent.speed = runSpeed;
			}
			//指定距離以上なら歩いてくる(=止まる距離)
			else if (distance > stopDistance)
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