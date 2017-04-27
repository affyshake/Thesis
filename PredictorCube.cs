using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictorCube : MonoBehaviour{
	public float speed = 1f;

	private Rigidbody target;
	private new Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update(){
		if(target == null){
			target = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>(); 
		}
		Vector3 newVelocity = ((target.transform.position + target.velocity) - transform.position).normalized * speed;
		rigidbody.velocity = newVelocity;
	}
}
