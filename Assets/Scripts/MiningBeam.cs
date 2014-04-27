using UnityEngine;
using System.Collections;

public class MiningBeam : MonoBehaviour {
	public bool mining = false;

	private float maxYScale = 2f;
	private SpriteRenderer spriteRenderer;
	private float mineTransitionTime = 5f;
	private float mineStartTime;
	private float mineStopTime;
	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);
	private BoxCollider2D boxCollider;
	
	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = transparent;
		transform.localScale = new Vector3 (transform.localScale.x, 0f, transform.localScale.z);
		boxCollider = gameObject.GetComponent<BoxCollider2D>();
	}
	
	void Update(){
		if(mining){
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, maxYScale, 0f), (Time.realtimeSinceStartup - mineStartTime) / mineTransitionTime);
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, opaque, (Time.realtimeSinceStartup - mineStartTime) / mineTransitionTime);
			// boxCollider.size = Vector2.Lerp (boxCollider.size, new Vector2(boxCollider.size.x, 1f), (Time.realtimeSinceStartup - mineStartTime) / mineTransitionTime);
		}else{
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, 0f, 0f), (Time.realtimeSinceStartup - mineStopTime) / mineTransitionTime);
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, transparent, (Time.realtimeSinceStartup - mineStopTime) / mineTransitionTime);
			// boxCollider.size = Vector2.Lerp (boxCollider.size, new Vector2(boxCollider.size.x, 0f), (Time.realtimeSinceStartup - mineStartTime) / mineTransitionTime);
		}
	}
	
	public void Mine(){
		mining = true;
		mineStartTime = Time.realtimeSinceStartup;
		// boxCollider.size = new Vector2(boxCollider.size.x, 0f);
	}

	public void Stop(){
		mining = false;
		mineStopTime = Time.realtimeSinceStartup;
	}
}
