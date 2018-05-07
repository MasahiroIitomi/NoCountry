using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class LittleElephantFollow : MonoBehaviour {
	Animator animator;
	public Transform target;
	NavMeshAgent agent;
	float distance;
	public float walkSpeed;
	public float runSpeed;
	public float stopDistance;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void Update (){
		distance = Vector3.Distance(transform.position, target.position);
		//50m以上離れるとその場でアイドリングする
		if (distance > 50.0f){
			agent.SetDestination(transform.position);
			animator.SetBool("Run", false);
			animator.SetBool("Walk", false);
		} 
		else
		{
			agent.SetDestination(target.position);
			//10m以上であれば走ってくる
			if (distance > 10.0f)
			{
				animator.SetBool("Run", true);
				agent.speed = runSpeed;
			} 
			//指定距離以上なら歩いてくる(それ以下なら停止してアイドル状態)
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