using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class ElephantFreeWalk : MonoBehaviour {
	Animator animator;
	GameObject target;
	NavMeshAgent agent;
	float distance; 
	public GameObject targetArea; //動物が歩行可能なエリアを示すNavMesh用に使用したオブジェクト
	float idleTime; //アイドル状態の経過時間
	float triggerTime; //walkingステートへ移行するトリガーとなる時間
	public float minTriggerTime;
	public float maxTriggerTime;

	public GameObject targetPrefab;	
	float targetAreaX;
	float targetAreaZ;
	public float agentStopDistance; //エージェントが停止する距離(アイドル状態に戻る距離)を入れる

	public float walkSpeed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		//歩行可能エリアのサイズを取得
		targetAreaX = targetArea.GetComponent<Renderer>().bounds.size.x;
		targetAreaZ = targetArea.GetComponent<Renderer>().bounds.size.z;

		triggerTime = Random.Range(minTriggerTime, maxTriggerTime);
		
		target = Instantiate(targetPrefab, 
				targetArea.transform.position + new Vector3(Random.Range(-targetAreaX /2, targetAreaX / 2), 0, Random.Range(-targetAreaZ / 2, targetAreaZ / 2)),
				Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		//目的地とagentの距離を随時取得
		distance = Vector3.Distance(transform.position, target.transform.position);
		//現在のステートを取得
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.IsName("metarig|idle")){
			idleTime += Time.deltaTime * 1.0f;
		}

		if (idleTime > triggerTime){
			agent.SetDestination(target.transform.position);
			if (distance > agentStopDistance){
				animator.SetBool("Walk", true);
				agent.speed = walkSpeed;
			}
			else
			{
				animator.SetBool("Walk", false);
				target.transform.position = targetArea.transform.position + new Vector3(Random.Range(-targetAreaX /2, targetAreaX / 2), 0, Random.Range(-targetAreaZ / 2, targetAreaZ / 2));			
				idleTime = 0f;
			}
			
		}
	}
}
