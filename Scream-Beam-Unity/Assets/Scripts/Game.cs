using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public PlayerControl playerS;
	public bool isPlaying;
	bool hasStarted;

    public GameObject[] enemy1;
    public GameObject[] enemy2;
    public GameObject[] enemy3;
	GameObject[] beams;
	
    GameObject enemyToSpawn;
    public float spawnRate;
	
	public float diffMod;
	float diffUpTime;
	float diffDelay = 1f;
	
	public float score;
	
	void Update () {
		//if the player has started the game and enemies are not spawning, spawn enemies
		if(isPlaying && !hasStarted){
			StartCoroutine(SpawnEnemies());
			hasStarted = true;
		}
		
		//if playing then decrease the spawn rate every (diffDelay) by (diffMod) else reset spawn rate and diff mod
		if(isPlaying){
			if(Time.time > diffUpTime){
				if(spawnRate > 0.5f){
					diffMod += 0.02f;
					diffUpTime += diffDelay;
				}
			}
		}else{
			spawnRate = 2;
			diffMod = 0;
		}
		spawnRate = 2 - diffMod;
		if(isPlaying){
			score += Time.deltaTime;
		}else{
			
		}
	}
	
	IEnumerator SpawnEnemies(){
		while (isPlaying){
			//get an idle enemy using GetEnemy, then set the enemy postion to the edge of the screen and enable the enemy script
			GameObject enemy = GetEnemy();
			if(enemy != null){
				enemy.transform.position = new Vector3(playerS.screenBounds[3].transform.position.x,Random.Range(playerS.screenBounds[0].transform.position.y - 0.75f, playerS.screenBounds[1].transform.position.y + 0.75f),0);
				enemy.GetComponent<Enemy>().enabled = true;
			}
			yield return new WaitForSeconds(spawnRate);
		}
	}
	
	GameObject GetEnemy(){
        if (Random.Range(0,100) > 80){								//20% chance to spawn a UFO
            foreach (GameObject gO in enemy3){
                if (gO.GetComponent<Enemy>().enabled == false){
                    return gO;
                }
            }
        }else if (Random.Range(0,2) == 0){							//if not UFO 33% chance to spawn a gun enemy
            foreach (GameObject gO in enemy2){
                if (gO.GetComponent<Enemy>().enabled == false){
                    return gO;
                }
            }
        }else{														//if not UFO or gun spawn a sword enemy
            foreach (GameObject gO in enemy1){
                if (gO.GetComponent<Enemy>().enabled == false){
                    return gO;
                }
            }
        }
        return null;
	}
	
	public void EndGame(){
		//reset all variables
		isPlaying = false;
		hasStarted = false;
		playerS.health = 3;
		//reset all enemy objects
		foreach (GameObject gO in enemy1){
            if (gO.GetComponent<Enemy>().enabled == true){
                gO.GetComponent<Enemy>().Reset();
            }
        }
		foreach (GameObject gO in enemy2){
            if (gO.GetComponent<Enemy>().enabled == true){
                gO.GetComponent<Enemy>().Reset();
            }
        }
		foreach (GameObject gO in enemy3){
            if (gO.GetComponent<Enemy>().enabled == true){
                gO.GetComponent<Enemy>().Reset();
            }
        }
		//reset all beams
		foreach (GameObject gO in playerS.beams){
            if (gO.GetComponent<Beam>().enabled == true){
                gO.GetComponent<Beam>().Reset();
            }
        }
	}
}
