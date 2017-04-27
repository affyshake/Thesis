using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject player;
	public Transform startPoint;
	public Transform[] spawnPoints;
	public GameObject[] cubes;
	public float timeLimit;
	public float spawnTime;

	private float currentSpawnTime;
	private float currentTime;
	private List<GameObject> currentCubes;

	// Use this for initialization
	void Start () {
		currentTime = 0f;
		currentCubes = new List<GameObject>();
		Instantiate(player,startPoint.position,Quaternion.identity).GetComponent<Rigidbody>();
		SpawnCube();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime >= timeLimit){
			EndGame();
		}else{
			if(currentSpawnTime >= spawnTime){
				SpawnCube();
			}
		}
		currentTime += Time.deltaTime;
		currentSpawnTime += Time.deltaTime;
	}

	private void SpawnCube(){
		var cube = Instantiate(cubes[Random.Range(0,cubes.Length)],spawnPoints[Random.Range(0,spawnPoints.Length)].position,Quaternion.identity);
		currentCubes.Add(cube);
		currentSpawnTime = 0f;
	}

	private void EliminateCubes(){
		for(int i=0;i<currentCubes.Count;++i){
			Destroy(currentCubes[i]);
		}
		currentCubes.Clear();
	}

	public void Reset(){
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}

	public void EndGame(){
		Application.Quit();
	}
}
