using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class StagFreeMove : MonoBehaviour {
	Animator animator;
	public GameObject targetPrefab; //目標地点の元となるプレハブをアサイン
	GameObject target; //目標地点を決定し複製したものを格納する変数
	NavMeshAgent agent;
	float distance; 
	public GameObject targetArea; //agentのtarget範囲を示すオブジェクト
	float idleTime; //アイドル状態の経過時間
	float triggerTime; //移動系ステートへ移行するトリガーとなる時間
	public float triggerMinTime;
	public float triggerMaxTime;
	float walkableAreaX;
	float walkableAreaZ;

	public float walkSpeed;
	public float runSpeed;

	public float runDistance;
	public float stopDistance;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		//歩行可能エリアのサイズを取得
		walkableAreaX = targetArea.GetComponent<Renderer>().bounds.size.x;
		walkableAreaZ = targetArea.GetComponent<Renderer>().bounds.size.z;

		triggerTime = Random.Range(triggerMinTime, triggerMaxTime);
		
		target = Instantiate(targetPrefab, 
				targetArea.transform.position + new Vector3(Random.Range(-walkableAreaX /2, walkableAreaX / 2), 0, Random.Range(-walkableAreaZ / 2, walkableAreaZ / 2)),
				Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		//目的地とagentの距離を随時取得
		distance = Vector3.Distance(transform.position, target.transform.position);
		//現在のステートを取得
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.IsName("metarig|Idle")){
			idleTime += Time.deltaTime * 1.0f;
		}

		if (idleTime > triggerTime){
			agent.SetDestination(target.transform.position);
			//指定距離以上であれば走る
			if (distance > runDistance)
			{
				animator.SetBool("Run", true);
				agent.speed = runSpeed;
			}
			else if (distance > stopDistance)
			{	
				animator.SetBool("Run", false);
				animator.SetBool("Walk", true);
				agent.speed = walkSpeed;
			}
			else
			{
				animator.SetBool("Walk", false);
				target.transform.position = targetArea.transform.position + new Vector3(Random.Range(-walkableAreaX /2, walkableAreaX / 2), 0, Random.Range(-walkableAreaZ / 2, walkableAreaZ / 2));			
				idleTime = 0f;
			}
			
		}
	}
}
