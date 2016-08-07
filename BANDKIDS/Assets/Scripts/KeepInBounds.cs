using UnityEngine;
using System.Collections;

public class KeepInBounds : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bandkids")
        {
            if (collision.transform.position.y < 0)
            {
                player.gameObject.GetComponent<CharacterController>().bottomBoundaryHit = true;
            }
            if (collision.transform.position.y > 0)
            {
                player.gameObject.GetComponent<CharacterController>().topBoundaryHit = true;
            }
        }

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bandkids")
        {
            if (collision.transform.position.y < 0)
            {
                player.gameObject.GetComponent<CharacterController>().bottomBoundaryHit = false;
            }
            if (collision.transform.position.y > 0)
            {
                player.gameObject.GetComponent<CharacterController>().topBoundaryHit = false;
            }
        }
    }

}
