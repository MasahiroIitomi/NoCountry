using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class BearMoveAttack : MonoBehaviour {
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
		//20m以上離れるとその場でアイドリングする
		if (distance > 10.0f){
			agent.SetDestination(transform.position);
			animator.SetBool("Run", false);
		} 
		else
		{
			agent.SetDestination(goal.position);
			if (distance > 3.0f)
			{
				animator.SetBool("Run", true);
				agent.speed = 10.0f;
			} 
			else
			{	
				animator.SetTrigger("Attack");
				animator.SetBool("Run", false);
			}
		}

		
	}
		
}