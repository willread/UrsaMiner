using UnityEngine;
using System.Collections;

public class Ore : MonoBehaviour {
	public bool scanned = false;
	public Sprite[] sprites;

	private Color opaque = new Color(1f, 1f, 1f, 1f);
	private Color transparent = new Color(1f, 1f, 1f, 0f);
	private GameObject ship;
	private bool beingMined = false;
	private float miningSpeed = 30f;
	private float pickupThreshold = 0.5f;
	private SpriteRenderer spriteRenderer;
	private float scanStartTime;
	private float mineStartTime;
	private float animTime = 1f;

	void Start(){
		ship = GameObject.FindGameObjectWithTag("Ship");
		renderer.material.color = transparent;
		transform.localScale = new Vector3(1f, 1f, 1f);

		// Set random sprite

		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites [Random.Range (0, sprites.Length - 1)];
	}

	void Update(){

		// Drag ore toward ship with mining beam

		if(beingMined){
			transform.position = Vector3.Lerp(transform.position, ship.transform.position, (Time.realtimeSinceStartup - mineStartTime) / miningSpeed);

			// Pick up ore when close enough
			
			if(Vector3.Distance(transform.position, ship.transform.position) <= pickupThreshold){
				Destroy(gameObject);
				ship.BroadcastMessage("MinedOre");
			}
		}

		// Animate ore when scanned

		if(scanned == true){
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(2f, 2f, 2f), 6f * Time.deltaTime);
			spriteRenderer.color = Color.Lerp(spriteRenderer.color, opaque, 0.3f * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Scanner"){
			scanned = true;
			scanStartTime = Time.realtimeSinceStartup;
			renderer.material.color = new Color(255, 255, 255, 1f);
		}

		if(collider.tag == "MiningBeam" && scanned && collider.GetComponent<MiningBeam>().mining == true && !beingMined){
			beingMined = true;
			mineStartTime =  Time.realtimeSinceStartup;
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(collider.tag == "MiningBeam" && scanned){
			beingMined = false;
		}
	}
}
