using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject[] asteroids;

	private float zoomSpeed = 3f;
	private float defaultZoom = -10f;
	private float farZoom = -30f;
	private float zoomThreshold = 15f;

	void Start(){
		// Fetch a list of all asteroids
		// Done here for optimization purposes
		asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
	}

	void Update(){
		// Fixed rotation
		// transform.rotation = Quaternion.Euler(Vector3.zero);

		// Zoom to make sure asteroid is visible
		/*

		bool visible = false;

		foreach(GameObject g in asteroids){
			Asteroid asteroid = g.GetComponent<Asteroid>();
			if(asteroid.IsVisible()){
				visible = true;
				continue;
			}
		}

		Vector3 cameraPos = Camera.main.transform.position;
		float targetZ = cameraPos.z;

		if(!visible){
			targetZ -= zoomSpeed * Time.deltaTime;
		}else{
			if(cameraPos.z < defaultZoom - zoomThreshold){
				targetZ += zoomSpeed * Time.deltaTime;
			}
		}
		*/

		// Alternate zoom method, just toggle between zoom levels

		float closestDistance = Mathf.Infinity;

		foreach(GameObject g in asteroids){
			float distance = Vector3.Distance(transform.parent.transform.position, g.transform.position);
			if(distance < closestDistance){
				closestDistance = distance;
			}
		}

		Vector3 cameraPos = Camera.main.transform.position;
		float targetZ = cameraPos.z;

		if(closestDistance < zoomThreshold && targetZ < defaultZoom){
			targetZ += zoomSpeed * Time.deltaTime;
		}

		if(closestDistance >= zoomThreshold && targetZ > farZoom){
			targetZ -= zoomSpeed * Time.deltaTime;
		}

		cameraPos.z = targetZ;
		Camera.main.transform.position = cameraPos;
	}


}
