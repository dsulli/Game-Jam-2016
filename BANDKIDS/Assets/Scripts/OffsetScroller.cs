using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour {

	public float scrollSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (-x, 0);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
		//renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);

	}
}
