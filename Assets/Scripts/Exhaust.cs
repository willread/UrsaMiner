using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {
	private float nextFlickerTime = 0f;
	void Update(){
		if(Time.timeSinceLevelLoad >= nextFlickerTime){
			transform.localScale = new Vector2(Random.Range(0.9f, 1.1f), Random.Range(0.6f, 0.7f));
			nextFlickerTime = Time.timeSinceLevelLoad + Random.Range(0.005f, 0.02f);
		}
	}
}
