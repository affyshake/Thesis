using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour {

	public float speed = 1f;
	public float maxSwitchTime = 2f;
	public float minSwitchTime = 1f;

	private float[] dx = {0f,1f,1f,1f,0f,-1f,-1f,-1f};
	private float[] dz = {1f,1f,0f,-1f,-1f,-1f,0f,1f};
	private float currentSwitchTime = 0f;
	private int currentDir;

	private new Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update(){
		if(currentSwitchTime <= 0f){
			currentSwitchTime = Random.Range(minSwitchTime,maxSwitchTime);
			currentDir = Random.Range(0,dx.Length);
		}else{
			currentSwitchTime -= Time.deltaTime;
		}

		rigidbody.velocity = new Vector3(dx[currentDir]*speed,0f,dz[currentDir]*speed);
	}
}
