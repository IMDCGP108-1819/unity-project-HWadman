using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	
	public bool isPlaying;
	bool hasStarted;
	
	float spawnDelay;
	
	void Update () {
		if(isPlaying && !hasStarted){
			spawnDelay = 7.0f;
			StartCoroutine(SpawnEnemies());
			hasStarted = true;
		}
	}
	
	IEnumerator SpawnEnemies(){
		while (isPlaying){
			GameObject enemy = GetEnemy();
			yield return new WaitForSeconds(spawnDelay);
		}
	}
	
	GameObject GetEnemy(){
		int enemyNum = 0;
		return gO;
	}
}
