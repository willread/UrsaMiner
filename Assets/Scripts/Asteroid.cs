using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public GameObject orePrefab;

	private float minDepth = 0.1f;
	private float maxDepth = 0.5f;
	private int minOre = 2;
	private int maxOre = 20;

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

			// Set position of ore, making sure to place it's z in front of the asteroid

			Vector3 randomPos = new Vector3(randomPoint.x, randomPoint.y, -0.0001f);
			ore.transform.localPosition = randomPos;
		}
	}

	// Tell whether this asteroid is visible in the main camera
	// Visible means the center of our transform being within the bounds of the camera
	// when translated into screen coordinates

	public bool IsVisible(){
		Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

		if(viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1){
			return false;
		}

		return true;
	}
}
