using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class LittleDeerFollow : MonoBehaviour {
	Animator animator;
	public Transform goal;
	NavMeshAgent agent;
	float distance;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
	}

	void Update (){
		distance = Vector3.Distance(transform.position, goal.position);
		//50m以上離れるとその場でアイドリングする
		if (distance > 50.0f){
			agent.SetDestination(transform.position);
			animator.SetBool("Run", false);
			animator.SetBool("Walk", false);
		} 
		else
		{
			agent.SetDestination(goal.position);
			//10m以上であれば走ってくる
			if (distance > 10.0f)
			{
				animator.SetBool("Run", true);
				agent.speed = 4.0f;
			} 
			//3m以上なら歩いてくる
			else if (distance > 3.0f)
			{
				animator.SetBool("Run", false);
				animator.SetBool("Walk", true);
				agent.speed = 1.0f;	
			}
			//それ以下ならアイドル状態に戻る
			else
			{
				animator.SetBool("Walk", false);			
			}
		}

		
	}
		
}