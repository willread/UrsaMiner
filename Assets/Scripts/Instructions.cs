using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	
	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);
	private bool visible = true;
	private SpriteRenderer spriteRenderer;
	
	void Start(){
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
