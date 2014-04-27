using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Initialize : MonoBehaviour {
	public GameObject[] asteroidPrefabs;

	private List<Vector3> asteroidPositions = new List<Vector3>(){
															new Vector3(-20, -40, 0), new Vector3(-10, -40, 0), new Vector3(0, -40, 0), new Vector3(10, -40, 0), new Vector3(20, -40, 0),
								  new Vector3(-30, -30, 0), new Vector3(-20, -30, 0), new Vector3(-10, -30, 0), new Vector3(0, -30, 0), new Vector3(10, -30, 0), new Vector3(20, -30, 0), new Vector3(30, -30, 0),
		new Vector3(-40, -20, 0), new Vector3(-30, -20, 0), new Vector3(-20, -20, 0), new Vector3(-10, -20, 0), new Vector3(0, -20, 0), new Vector3(10, -20, 0), new Vector3(20, -20, 0), new Vector3(30, -20, 0), new Vector3(40, -20, 0),
		new Vector3(-40, -10, 0), new Vector3(-30, -10, 0), new Vector3(-20, -10, 0), new Vector3(-10, -10, 0), new Vector3(0, -10, 0), new Vector3(10, -10, 0), new Vector3(20, -10, 0), new Vector3(30, -10, 0), new Vector3(40, -10, 0),
		new Vector3(-40,   0, 0), new Vector3(-30,   0, 0), new Vector3(-20,   0, 0), new Vector3(-10,   0, 0), 						new Vector3(10,   0, 0), new Vector3(20,   0, 0), new Vector3(30,   0, 0), new Vector3(40,   0, 0),
		new Vector3(-40,  10, 0), new Vector3(-30,  10, 0), new Vector3(-20,  10, 0), new Vector3(-10,  10, 0), new Vector3(0,  10, 0), new Vector3(10,  10, 0), new Vector3(20,  10, 0), new Vector3(30,  10, 0), new Vector3(40,  10, 0),
		new Vector3(-40,  20, 0), new Vector3(-30,  20, 0), new Vector3(-20,  20, 0), new Vector3(-10,  20, 0), new Vector3(0,  20, 0), new Vector3(10,  20, 0), new Vector3(20,  20, 0), new Vector3(30,  20, 0), new Vector3(40,  20, 0),
								  new Vector3(-30,  30, 0), new Vector3(-20,  30, 0), new Vector3(-10,  30, 0), new Vector3(0,  30, 0), new Vector3(10,  30, 0), new Vector3(20,  30, 0), new Vector3(30,  30, 0),
															new Vector3(-20,  40, 0), new Vector3(-10,  40, 0), new Vector3(0,  40, 0), new Vector3(10,  40, 0), new Vector3(20,  40, 0)
	};

	void Start(){
		int numAsteroids = 30;

		for(int ii = 0; ii < numAsteroids; ii++){
			if(asteroidPositions.Count <= 0){
				break;
			}

			Vector3 pos = asteroidPositions[Random.Range (0, asteroidPositions.Count)];
			asteroidPositions.Remove(pos);

			GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
			GameObject asteroid = (GameObject)GameObject.Instantiate(asteroidPrefab);

			asteroid.transform.position = pos;
			asteroid.transform.eulerAngles = new Vector3(0f, 0f, Random.rotation.eulerAngles.z);
		}
	}
}
