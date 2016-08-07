using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Keeps track of members in the band.
/// </summary>

public class BandController : MonoBehaviour {

    //public static List<GameObject> band = new List<GameObject>();
    public static GameObject[,] band = new GameObject[15,9];
    public GameObject player;
    protected int rotations = 0;
    public static int bandMembers = 1;
	// Use this for initialization
	void Start () {
        if(player != null)
        {
            //band.Add(player);
            band[0, 4] = player;
        }
        
	
	}
	
	// Update is called once per frame
	void Update () {
        player.GetComponent<CharacterController>().speedMultiplier = 3.0f / (float)bandMembers ;
        
 
	}


}
