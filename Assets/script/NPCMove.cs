using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCMove : MonoBehaviour {

	[SerializeField]
	private Transform _destination;

	private NavMeshAgent _navMeshAgent;

	void start(){
		_navMeshAgent = this.GetComponent<NavMeshAgent>();

		if(_navMeshAgent == null){
			Debug.LogError("The navMeshAgent is not attached to "+ gameObject.name);
		}else{
			SetDestination();
		}
	}

	private void SetDestination(){
		if (_destination!= null){
			Vector3 targetVector = _destination.transform.position;
			_navMeshAgent.SetDestination(targetVector);
		}

	}
	
}
