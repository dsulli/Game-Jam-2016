using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

    public float maxSpeed;
    Rigidbody2D rigidbody2d = new Rigidbody2D();
    public float speedMultiplier = 1.0f;
    public bool bottomBoundaryHit = false;
    public bool topBoundaryHit = false;

	// Use this for initialization
	void Start () {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        
	
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        if(speedMultiplier > 1)
        {
            speedMultiplier = 1.0f;
        }
        
        if(bottomBoundaryHit && moveY < 0)
        {
            moveY = 0;
        }
        if (topBoundaryHit && moveY > 0)
        {
            moveY = 0;
        }
        rigidbody2d.velocity = new Vector2(moveX * maxSpeed * speedMultiplier, moveY * maxSpeed * speedMultiplier);

        
	
	}
}
