using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	protected Rigidbody target;
	protected new Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	protected virtual void Move(){
	}

	public void SetTarget(Rigidbody t){
		target = t;
	}
}
