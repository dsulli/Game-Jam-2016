using UnityEngine;
using System.Collections;

/// <summary>
/// Script controls the movement behavior of Band Kids and Obstacles
/// </summary>
public class Movement : MonoBehaviour {

    public bool isGrouped = false;
    Rigidbody2D rbody2D = new Rigidbody2D();

	// Use this for initialization
	void Start () {
        rbody2D = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!isGrouped)
        {
            rbody2D.velocity = new Vector2(2.0f,0);
        }
        
	
	}
}
