using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour {
	public bool scanned = false;

	private GameObject ship;
	private bool beingMined = false;
	private float miningSpeed = 1f;
	private float pickupThreshold = 0.5f;

	void Start(){
		ship = GameObject.FindGameObjectWithTag("Ship");
		renderer.material.color = new Color(255, 255, 255, 0f);
	}

	void Update(){

		// Drag ore toward ship with mining beam

		if(beingMined){
			transform.position = Vector3.Lerp(transform.position, ship.transform.position, miningSpeed * Time.deltaTime);

			// Pick up ore when close enough
			
			if(Vector3.Distance(transform.position, ship.transform.position) <= pickupThreshold){
				Destroy(gameObject);
				ship.BroadcastMessage("MinedOre");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Scanner"){
			scanned = true;
			renderer.material.color = new Color(255, 255, 255, 1f);
		}

		if(collider.tag == "MiningBeam" && scanned){
			beingMined = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(collider.tag == "MiningBeam" && scanned){
			Debug.Log ("No More Mining");
			beingMined = false;
		}
	}
}
