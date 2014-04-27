using UnityEngine;
using System.Collections;

public class MiningBeam : MonoBehaviour {
	private bool mining = false;
	private float maxYScale = 2f;
	private SpriteRenderer spriteRenderer;
	private float mineTransitionTime = 5f;
	private float mineStartTime;
	private float mineStopTime;
	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);
	
	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = transparent;
		transform.localScale = new Vector3 (transform.localScale.x, 0f, transform.localScale.z);
	}
	
	void Update(){
		if(mining){
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, maxYScale, 0f), (Time.realtimeSinceStartup - mineStartTime) / mineTransitionTime);
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, opaque, (Time.realtimeSinceStartup - mineStartTime) / mineTransitionTime);
		}else{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, 0f, 0f), (Time.realtimeSinceStartup - mineStopTime) / mineTransitionTime);
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, transparent, (Time.realtimeSinceStartup - mineStopTime) / mineTransitionTime);
		}
	}
	
	public void Mine(){
		mining = true;
		mineStartTime = Time.realtimeSinceStartup;
	}

	public void Stop(){
		mining = false;
		mineStopTime = Time.realtimeSinceStartup;

	}
}
