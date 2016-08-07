using UnityEngine;
using System.Collections;

/// <summary>
/// Controls behaviors within the game
/// </summary>
public class GameController : MonoBehaviour {

    public GameObject bandKid;
    public Vector3 spawnValue;
    public int bandKidCount;
    public float startWait;
    public float spawnWait;
    
   


	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnBandKid());
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Spawns an object
    IEnumerator SpawnBandKid()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for(int i = 0; i < bandKidCount; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y), spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(bandKid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }
        
    }
}
