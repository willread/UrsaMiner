using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour {
	public bool scanned = false;

	void Start(){
		renderer.material.color = new Color(255, 255, 255, 0f);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Scanner"){
			scanned = true;
			renderer.material.color = new Color(255, 255, 255, 1f);
		}

		if(collider.tag == "MiningBeam" && scanned){
			Debug.Log ("MiningBeam");
		}
	}
}
