using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);
	private bool visible = true;
	private SpriteRenderer spriteRenderer;

	void Start(){
		gameObject.AddComponent<Rigidbody2D>();
		rigidbody2D.gravityScale = 0f;
		rigidbody2D.mass = 1f;
		rigidbody2D.AddForce(Random.insideUnitSphere * 2f);
		rigidbody2D.AddTorque(Random.Range(-50f, 50f));
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update(){
		if(!visible){
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, transparent, 2f * Time.deltaTime);
		}
	}

	void Hide(){
		visible = false;
	}
}
