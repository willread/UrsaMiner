using UnityEngine;
using System.Collections;

public class Scanner : MonoBehaviour {
	private bool scanning = false;
	private float maxScale = 1f;
	private SpriteRenderer spriteRenderer;
	private CircleCollider2D circleCollider;
	private float circleColliderRadius = 4.5f;
	private float scanTime = 2f;
	private float scanStartTime;
	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);

	void Start(){
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = transparent;
		circleCollider = gameObject.GetComponent<CircleCollider2D>();
	}

	void Update(){
		/*
		Vector3 mousePos = Input.mousePosition;
		Vector3 worldPos = Camera.main.WorldToScreenPoint (transform.position);

		mousePos.x -= worldPos.x;
		mousePos.y -= worldPos.y;

		float angle = Mathf.Atan2 (mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
		*/

		if(scanning){
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(maxScale, maxScale, 0f), (Time.realtimeSinceStartup - scanStartTime) / scanTime);
			circleCollider.radius = Mathf.Lerp(circleCollider.radius, circleColliderRadius, (Time.realtimeSinceStartup - scanStartTime) / scanTime);
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, opaque, (Time.realtimeSinceStartup - scanStartTime) / (scanTime / 4));
		}else{
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, transparent, (Time.realtimeSinceStartup - scanStartTime) / (scanTime));
		}

		if(spriteRenderer.color == opaque){
			scanning = false;
		}
	}

	public void Scan(Vector3 position){
		transform.position = position;
		scanning = true;
		scanStartTime = Time.realtimeSinceStartup;
		spriteRenderer.color = transparent;
		transform.localScale = new Vector3 (0f, 0f, 0f);
		circleCollider.radius = 0f;
	}
}
