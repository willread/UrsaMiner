using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);
	private bool visible = true;
	private SpriteRenderer spriteRenderer;

	void Start(){
		gameObject.AddComponent<Rigidbody2D>();
		GetComponent<Rigidbody2D>().gravityScale = 0f;
		GetComponent<Rigidbody2D>().mass = 1f;
		GetComponent<Rigidbody2D>().AddForce(Random.insideUnitSphere * 2f);
		GetComponent<Rigidbody2D>().AddTorque(Random.Range(-50f, 50f));
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
