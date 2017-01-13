using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject bug;
	public Vector3 spawnPoint;
	public float spawnWait;
	public float startWait;
	public float waveWait; 
	public int maxBugs; 

	void Start(){
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < maxBugs; i++) {
					
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnPoint.x, spawnPoint.x), spawnPoint.y, spawnPoint.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (bug, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);		
			}
			yield return new WaitForSeconds (waveWait); 
		}
	}
	// Update is called once per frame
//	void Update () {
//		SpawnBug ();
//	}
}
