using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class WalkingHorse : MonoBehaviour {
	Animator animator;
	public GameObject targetPrefab; //目標地点の元となるプレハブをアサイン
	GameObject target; //目標地点を決定し複製したものを格納する変数
	NavMeshAgent agent;
	float distance; 
	public GameObject walkableArea; //動物が歩行可能なエリアを示すNavMesh用に使用したオブジェクト
	float idleTime; //アイドル状態の経過時間
	public float triggerTime; //walkingステートへ移行するトリガーとなる時間
	float walkableAreaX;
	float walkableAreaZ;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		//歩行可能エリアのサイズを取得
		walkableAreaX = walkableArea.GetComponent<Renderer>().bounds.size.x;
		walkableAreaZ = walkableArea.GetComponent<Renderer>().bounds.size.z;
		
		target = Instantiate(targetPrefab, 
				walkableArea.transform.position + new Vector3(Random.Range(-walkableAreaX /2, walkableAreaX / 2), 0, Random.Range(-walkableAreaZ / 2, walkableAreaZ / 2)),
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
			//40m以上であれば走る
			if (distance > 40.0f)
			{
				animator.SetBool("Run", true);
				agent.speed = 8.0f;
			}
			else if (distance > 10.0f)
			{	
				animator.SetBool("Run", false);
				animator.SetBool("Walk", true);
				agent.speed = 1.5f;
			}
			else
			{
				animator.SetBool("Walk", false);
				target.transform.position = walkableArea.transform.position + new Vector3(Random.Range(-walkableAreaX /2, walkableAreaX / 2), 0, Random.Range(-walkableAreaZ / 2, walkableAreaZ / 2));			
				idleTime = 0f;
			}
			
		}
	}
}
