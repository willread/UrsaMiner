using UnityEngine;
using System.Collections;

public class PressToContinue : MonoBehaviour {
	private bool show = false;

	void Start () {
		transform.localScale = Vector3.zero;
	}

	void Update () {
		if(show){
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 1f * Time.deltaTime);
		}
	}

	void Show(){
		show = true;
	}
}
