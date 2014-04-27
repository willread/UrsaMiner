using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public GameObject orePrefab;

	public float minDepth = 0.0f;
	public float maxDepth = 0.0f;
	public int minOre = 1;
	public int maxOre = 15;

	// Initialize a new asteroid

	public void Start(){

		// Generate a random number of ore, within the specified range

		int numOre = Random.Range(minOre, maxOre);

		for(int ii = 0; ii < numOre; ii++){

			// Instantiate a new ore object and parent it to the asteroid

			GameObject ore = (GameObject)Instantiate(orePrefab);
			ore.transform.parent = gameObject.transform;

			// Pick a random point along the outside of the asteroid collider

			PolygonCollider2D p = (PolygonCollider2D)collider2D;
			Vector2 randomPoint = p.points[Random.Range (0, p.points.Length)];

			// Move it to a random depth in the specified range

			float randomDepth = Random.Range(minDepth, maxDepth);
			randomPoint = Vector2.Lerp(randomPoint, Vector2.zero, randomDepth);

			// Set position of ore

			Vector3 randomPos = new Vector3(randomPoint.x, randomPoint.y, 0f);
			ore.transform.localPosition = randomPos;
		}
	}
}
